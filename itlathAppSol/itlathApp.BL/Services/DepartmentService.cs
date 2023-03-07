using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using itlathApp.BL.Core;
using itlathApp.DAL.Interfaces;
using itlathApp.BL.Models;
using itlathApp.BL.Dtos.Department;
using itlathApp.DAL.Entities;

namespace itlathApp.BL.Services
{
    public class DepartmentService : Contract.IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILogger<DepartmentService> logger;

        public DepartmentService(IDepartmentRepository departmentRepository,
                                 ILogger<DepartmentService> logger)
        {
            this.departmentRepository = departmentRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("consutando los deparmentos");

                var departments = this.departmentRepository
                                      .GetEntities()
                                      .Select(dep => new DepartmentModel()
                                      {
                                          DepartmentID = dep.DepartmentID,
                                          Budget = dep.Budget,
                                          CreateDate = dep.CreationDate,
                                          Name = dep.Name,
                                          StartDate = dep.StartDate
                                      }).ToList();

                result.Data = departments;

                this.logger.LogInformation("se consultaron los deparmentos");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los departamentos";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("consutando el deparmento");

                var department = this.departmentRepository.GetEntity(Id);

                DepartmentModel departmentModel = new DepartmentModel()
                {
                    DepartmentID = department.DepartmentID,
                    Budget = department.Budget,
                    CreateDate = department.CreationDate,
                    Name = department.Name,
                    StartDate = department.StartDate
                };

                result.Data = departmentModel;

                this.logger.LogInformation("se consultó el deparmento");
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo el departamento";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult RemoveDepartment(DepartmentRemoveDto departmentRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                DAL.Entities.Department department = this.departmentRepository.GetEntity(departmentRemove.DepartmentId);

                department.DepartmentID = departmentRemove.DepartmentId;
                department.DeletedDate = departmentRemove.RemoveDate;
                department.Deleted = true;
                department.UserDeleted = departmentRemove.RemoveUser;

                this.departmentRepository.Update(department);
                this.departmentRepository.SaveChanges();

                result.Message = "El departamento fue removido correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error removiendo el departamento";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }
        public ServiceResult SaveDepartment(DepartmentAddDto departmentAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Department department = new Department()
                {
                    Administrator = departmentAdd.Administrator,
                    Budget = departmentAdd.Budget,
                    CreationDate = departmentAdd.CreateDate,
                    CreationUser = departmentAdd.CreateUser,
                    Name = departmentAdd.Name,
                    StartDate = departmentAdd.StartDate
                };

                this.departmentRepository.Save(department);
                this.departmentRepository.SaveChanges();

                result.Message = "El departamento fue guardado correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error guardando el departamento";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
        public ServiceResult UpdateDepartment(DepartmentUpdateDto departmentUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Department department = this.departmentRepository.GetEntity(departmentUpdate.DepartmentId);

                department.DepartmentID = departmentUpdate.DepartmentId;
                department.Administrator = departmentUpdate.Administrator;
                department.Budget = departmentUpdate.Budget;
                department.ModifyDate = departmentUpdate.ModifyDate;
                department.UserMod = departmentUpdate.ModifyUser;
                department.Name = departmentUpdate.Name;
                department.StartDate = departmentUpdate.StartDate;

                this.departmentRepository.Update(department);
                this.departmentRepository.SaveChanges();

                result.Message = "El departamento fue modificado correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error guardando el departamento";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
    }
}

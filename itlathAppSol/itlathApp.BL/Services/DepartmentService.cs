using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using itlathApp.BL.Core;
using itlathApp.DAL.Interfaces;
using itlathApp.BL.Models;

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
    }
}

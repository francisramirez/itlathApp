using System;
using System.Collections.Generic;
using System.Linq;
using itlathApp.DAL.Context;
using itlathApp.DAL.Entities;
using itlathApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace itlathApp.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ItlaContext context;
        private readonly ILogger<DepartmentRepository> ilogger;

        public DepartmentRepository(ItlaContext context,
                                    ILogger<DepartmentRepository> ilogger)
        {
            this.context = context;
            this.ilogger = ilogger;
        }
        public bool Exists(string name)
        {
            return this.context.Departments.Any(st => st.Name == name);
        }

        public List<Department> GetAll()
        {
            return this.context.Departments
                       .Where(dep => !dep.Deleted)
                       .ToList();
        }

        public Department GetById(int departmentId)
        {
            return this.context.Departments.Find(departmentId);
        }

        public void Remove(Department department)
        {
            try
            {
                Department departmentToRemove = this.GetById(department.DepartmentID);
                departmentToRemove.DeletedDate = DateTime.Now;
                departmentToRemove.UserDeleted = 1;
                departmentToRemove.Deleted = true;

                this.context.Departments.Update(departmentToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error removiendo el departamento { ex.Message } ", ex.ToString());
            }
        }

        public void Save(Department department)
        {
            try
            {
                Department departmentToAdd = new Department()
                {
                    CreationUser = department.CreationUser,
                    CreationDate = DateTime.Now,
                    Budget = department.Budget,
                    Administrator = department.Administrator,
                    Name = department.Name,
                    StartDate = department.StartDate
                };

                this.context.Departments.Add(departmentToAdd);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error guardando el departamento { ex.Message } ", ex.ToString());
            }
        }

        public void Update(Department department)
        {

            try
            {
                Department departmentToUpdate = this.GetById(department.DepartmentID);

                departmentToUpdate.DepartmentID = department.DepartmentID;
                departmentToUpdate.Name = department.Name;
                departmentToUpdate.StartDate = department.StartDate;
                departmentToUpdate.Budget = department.Budget;
                departmentToUpdate.Administrator = department.Administrator;
                departmentToUpdate.ModifyDate = DateTime.Now;
                departmentToUpdate.UserMod = department.UserMod;

                this.context.Departments.Update(departmentToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error actualizando el departamento { ex.Message } ", ex.ToString());
            }
        }
    }
}

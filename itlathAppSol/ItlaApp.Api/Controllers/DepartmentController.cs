using System;
using System.Linq;
using System.Threading.Tasks;
using itlathApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using itlathApp.DAL.Entities;
using ItlaApp.Api.Requests;

namespace ItlaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var departments = this.departmentRepository.GetEntities();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var department = this.departmentRepository.GetEntity(id);
            return Ok(department);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] DepartmentAddRequest departmentAdd)
        {
            Department department = new Department()
            {
                Administrator = departmentAdd.Administrator,
                Budget = departmentAdd.Budget,
                CreationDate = departmentAdd.CreateDate,
                CreationUser = departmentAdd.CreateUser,
                Name = departmentAdd.Name,
                StartDate = departmentAdd.StartDate, 
            };

            this.departmentRepository.Save(department);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] Department department)
        {
            this.departmentRepository.Update(department);
            return Ok();
        }

        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] Department department)
        {
            this.departmentRepository.Remove(department);
            return Ok();
        }
    }
}

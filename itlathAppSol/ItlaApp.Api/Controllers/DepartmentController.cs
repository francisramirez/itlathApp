using System;
using System.Linq;
using System.Threading.Tasks;
using itlathApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using itlathApp.DAL.Entities;
using ItlaApp.Api.Requests;
using itlathApp.BL.Contract;
using itlathApp.BL.Dtos.Department;

namespace ItlaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = this.departmentService.GetAll();

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.departmentService.GetById(id);
            return Ok(result);
        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] DepartmentAddRequest departmentAdd)
        {
            DepartmentAddDto department = new DepartmentAddDto()
            {
                Administrator = departmentAdd.Administrator,
                Budget = departmentAdd.Budget,
                CreateDate = departmentAdd.CreateDate,
                CreateUser = departmentAdd.CreateUser,
                Name = departmentAdd.Name,
                StartDate = departmentAdd.StartDate,
            };

            var result =  this.departmentService.SaveDepartment(department);
            
            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] DepartmentUpdateDto department)
        {
           var result= this.departmentService.UpdateDepartment(department);
            return Ok(result);
        }

        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] DepartmentRemoveDto department)
        {
            var result = this.departmentService.RemoveDepartment(department);
            return Ok(result);
        }
    }
}

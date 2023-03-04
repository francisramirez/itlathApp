using System;
using System.Linq;
using System.Threading.Tasks;
using itlathApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using itlathApp.DAL.Entities;
using ItlaApp.Api.Requests;
using itlathApp.BL.Contract;

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
            Department department = new Department()
            {
                Administrator = departmentAdd.Administrator,
                Budget = departmentAdd.Budget,
                CreationDate = departmentAdd.CreateDate,
                CreationUser = departmentAdd.CreateUser,
                Name = departmentAdd.Name,
                StartDate = departmentAdd.StartDate, 
            };

            //this.departmentRepository.Save(department);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] Department department)
        {
           // this.departmentRepository.Update(department);
            return Ok();
        }

        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] Department department)
        {
            //this.departmentRepository.Remove(department);
            return Ok();
        }
    }
}

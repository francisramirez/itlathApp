using itlathApp.DAL.Entities;
using itlathApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        // GET: api/<StudentController>
        [HttpGet()]
        public IActionResult Get()
        {
            var students = this.studentRepository.GetAll();
            return Ok(students);
        }

        // GET api/<StudentController>/5
       [HttpGet("{id}")]
       public IActionResult Get(int id)
        {
            var student = this.studentRepository.GetById(id);
            return Ok(student);
        }
        
        [HttpPost("Save")]
        public IActionResult Post([FromBody] Student value)
        {
            return Ok();
        }

       
        [HttpPost("Update")]
        public IActionResult Put([FromBody] Student value)
        {
            return Ok();
        }

        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] Student value)
        {
            return Ok();
        }
    }
}

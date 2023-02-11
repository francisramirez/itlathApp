using itlathApp.DAL.Entities;
using itlathApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return this.studentRepository.GetAll();
        }

        public Student Get(int id)
        {
            return this.studentRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Student student)
        {
            this.studentRepository.Save(student);
        }
        [HttpPost]
        public void Put(Student student)
        {
            this.studentRepository.Update(student);
        }
        [HttpPost]
        public void Delete(Student student)
        {
            this.studentRepository.Remove(student);
        }
    }
}

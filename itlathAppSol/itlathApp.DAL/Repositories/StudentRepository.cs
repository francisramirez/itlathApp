using System.Collections.Generic;
using itlathApp.DAL.Entities;
using itlathApp.DAL.Context;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using itlathApp.DAL.Interfaces;

namespace itlathApp.DAL.Repositories
{
    public class StudentRepository : Core.RepositoryBase<Student> ,IStudentRepository
    {
        private readonly ItlaContext itlaContext;
        private readonly ILogger<StudentRepository> logger;

        public StudentRepository(ItlaContext itlaContext,
                                 ILogger<StudentRepository> logger): base(itlaContext)
        {
            this.itlaContext = itlaContext;
            this.logger = logger;
        }

        public Student GetStudentByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

    }
}

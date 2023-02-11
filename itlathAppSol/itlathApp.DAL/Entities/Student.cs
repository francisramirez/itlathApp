using itlathApp.DAL.Core;
using System;

namespace itlathApp.DAL.Entities
{
    public class Student : Person
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}


using itlathApp.DAL.Core;
using System;

namespace itlathApp.DAL.Entities
{
    public class Instructor : Person
    {
        public int Id { get; set; }
        public DateTime? HireDate { get; set; }
    }
}

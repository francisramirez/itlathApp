using System;


namespace itlathApp.BL.Dtos.Department
{
    public class DepartmentAddDto
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public int? Administrator { get; set; }
    }
}

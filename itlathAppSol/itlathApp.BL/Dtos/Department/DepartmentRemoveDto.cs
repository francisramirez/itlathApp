using System;

namespace itlathApp.BL.Dtos.Department
{
    public class DepartmentRemoveDto
    {
        public int DepartmentId { get; set; }
        public DateTime RemoveDate { get; set; }
        public int RemoveUser { get; set; }
    }
}

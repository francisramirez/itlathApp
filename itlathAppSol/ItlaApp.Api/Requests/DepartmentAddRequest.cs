using System;

namespace ItlaApp.Api.Requests
{
    public class DepartmentAddRequest : RequestAddBase
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }
    }
}

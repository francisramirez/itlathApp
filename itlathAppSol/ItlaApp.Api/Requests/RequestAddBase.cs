using System;

namespace ItlaApp.Api.Requests
{
    public abstract class RequestAddBase
    {
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
    }
}

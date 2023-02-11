using Microsoft.EntityFrameworkCore;
using itlathApp.DAL.Entities;

namespace itlathApp.DAL.Context
{
    public class ItlaContext : DbContext
    {
       
        public ItlaContext(DbContextOptions<ItlaContext> options)
            : base(options)
        {

        }
        #region "Registros"
        public DbSet<Student> Students { get; set; }
        #endregion
    }
}

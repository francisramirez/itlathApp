using itlathApp.DAL.Context;
using itlathApp.DAL.Core;
using itlathApp.DAL.Entities;
using itlathApp.DAL.Interfaces;

namespace itlathApp.DAL.Repositories
{
    public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
    {
        private readonly ItlaContext context;
        public InstructorRepository(ItlaContext context):base(context)
        {
            this.context = context;
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using itlathApp.DAL.Context;
using itlathApp.DAL.Entities;
using itlathApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace itlathApp.DAL.Repositories
{
    public class DepartmentRepository : Core.RepositoryBase<Department>, IDepartmentRepository
    {
        private readonly ItlaContext context;
        private readonly ILogger<DepartmentRepository> ilogger;

        public DepartmentRepository(ItlaContext context,
                                    ILogger<DepartmentRepository> ilogger): base(context)
        {
            this.context = context;
            this.ilogger = ilogger;
        }
        public override List<Department> GetEntities()
        {
            return this.context.Departments
                               .Where(de => !de.Deleted)
                               .OrderByDescending(cd => cd.CreationDate).ToList();
        }

    }
}

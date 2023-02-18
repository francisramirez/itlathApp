using itlathApp.DAL.Entities;
using System.Collections.Generic;

namespace itlathApp.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        void Save(Department  department);
        void Update(Department department);
        void Remove(Department department);
        Department GetById(int departmentId);
        List<Department> GetAll();
        bool Exists(string name);
    }
}

using itlathApp.DAL.Entities;
using System.Collections.Generic;

namespace itlathApp.DAL.Interfaces
{
    public interface IStudentRepository
    {
        void Save(Student student);
        void Update(Student student);
        void Remove(Student student);
        Student GetById(int studentId);
        List<Student> GetAll();
        bool Exists(string name);
    }
}

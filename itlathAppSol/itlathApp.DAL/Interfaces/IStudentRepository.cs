using itlathApp.DAL.Entities;

namespace itlathApp.DAL.Interfaces
{
    public interface IStudentRepository : Core.IRepositoryBase<Student>
    {
        Student GetStudentByCourse(int courseId);
    }
}

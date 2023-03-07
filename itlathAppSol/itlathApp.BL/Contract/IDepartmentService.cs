using itlathApp.BL.Core;
using itlathApp.BL.Dtos.Department;

namespace itlathApp.BL.Contract
{
    public interface IDepartmentService : IBaseService
    {
        ServiceResult SaveDepartment(DepartmentAddDto departmentAdd);
        ServiceResult UpdateDepartment(DepartmentUpdateDto departmentUpdate);
        ServiceResult RemoveDepartment(DepartmentRemoveDto departmentRemove);
    }
}

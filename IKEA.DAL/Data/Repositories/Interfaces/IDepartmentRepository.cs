using IKEA.DAL.Models;

namespace IKEA.DAL.Data.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments(bool withtracking = false);
        Department GetDepartmentById(int id);
        int AddDepartment(Department department);
        int UpdateDepartment(Department department);
        int DeleteDepartment(Department department);
    }
}

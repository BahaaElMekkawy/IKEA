using IKEA.BLL.Dto.Department;

namespace IKEA.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        int AddDepartment(CreateDepartmentDto createDepartmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentsDetailsDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDto updateDepartmentsDto);
    }
}
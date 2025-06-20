using IKEA.BLL.Dto.Department;
using IKEA.BLL.Factories;
using IKEA.DAL.Data.Repositories.Interfaces;


namespace IKEA.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetDepartments();

            //Get all Departments , but if i retuen a department it will return all the datat in the model 
            //so i will create a new model to return only the data i want
            //and i will use the select method to select the data i want

            ///1.Manual Mapping 
            ///var departmentDtos = departments.Select(d => new DepartmentDto
            ///{
            ///    Id = d.Id,
            ///    Name = d.Name,
            ///    Code = d.Code,
            ///    Description = d.Description,
            ///    DateOfCreation = DateOnly.FromDateTime(d.CreatedOn.Value)
            ///});
            ///return departmentDtos;

            //2.Extension Method 
            return departments.Select(d => d.ToDepartmentDto());

        }

        public DepartmentsDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
                return null;
            return department.ToDepartmentsDetailsDto();
        }

        public int AddDepartment(CreateDepartmentDto createDepartmentDto)
        {
            var department = createDepartmentDto.ToDepartment();
            return _departmentRepository.AddDepartment(department);
        }

        public int UpdateDepartment(UpdateDepartmentDto updateDepartmentsDto)
        {
            return _departmentRepository.UpdateDepartment(updateDepartmentsDto.ToDepartment());
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
                return false;
            int result = _departmentRepository.DeleteDepartment(department);
            return result > 0 ? true : false;
        }

    }
}

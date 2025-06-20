using AutoMapper;
using IKEA.BLL.Dto.Employee;
using IKEA.DAL.Data.Repositories.Interfaces;
using IKEA.DAL.Models.Employee;

namespace IKEA.BLL.Services.Employee
{
    public class EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeService
    {
        public int CreateEmployee(CreatedEmployeeDto employee)
        {
            var newEmployee = _mapper.Map<CreatedEmployeeDto, DAL.Models.Employee.Employee>(employee);
            return _employeeRepository.Add(newEmployee);
        }

        public bool DeleteEmployee(int id)
        {
            // We will apply soft Delete
            var employee = _employeeRepository.GetById(id);
            if (employee == null) return false;
            employee.IsDeleted = true;
            return _employeeRepository.Update(employee) > 0;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking)
        {
            var employees = _employeeRepository.GetAll(withTracking);
            // src = Ienumrable<Employee> => dest = IEnumrable<EmployeeDto>
            var returnedEmployees = _mapper.Map<IEnumerable<DAL.Models.Employee.Employee>, IEnumerable<EmployeeDto>>(employees);
            //var returnedEmployees = employees.Select(emp => new EmployeeDto()
            //{
            //    Id = emp.Id,
            //    Name = emp.Name,
            //    Age = emp.Age,
            //    Email = emp.Email,
            //    Salary = emp.Salary,
            //    IsActive = emp.IsActive,
            //    EmployeeType = emp.EmployeeType.ToString(),
            //    Gender = emp.Gender.ToString()
            //});
            return returnedEmployees;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var Employee = _employeeRepository.GetById(id);
            //if (Employee == null) return null;
            //var returnEmployee = new EmployeeDetailsDto()
            //{
            //    Id = Employee.Id,
            //    Name = Employee.Name,
            //    Age = Employee.Age,
            //    Address = Employee.Address,
            //    Salary = Employee.Salary,
            //    IsActive = Employee.IsActive,
            //    Email = Employee.Email,
            //    PhoneNumber = Employee.PhoneNumber,
            //    EmployeeType = Employee.EmployeeType.ToString(),
            //    Gender = Employee.Gender.ToString(),
            //    HiringDate = DateOnly.FromDateTime(Employee.HiringDate),
            //    CreatedBy = 1,
            //    LastModifiedBy = 1,
            //};
            //return returnEmployee;
            return Employee is null ? null : _mapper.Map<DAL.Models.Employee.Employee, EmployeeDetailsDto>(Employee);

        }

        public int UpdateEmployee(UpdatedEmployeeDto employee)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, DAL.Models.Employee.Employee>(employee));
        }
    }
}

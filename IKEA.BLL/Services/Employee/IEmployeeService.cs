using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Dto.Employee;

namespace IKEA.BLL.Services.Employee
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int CreateEmployee(CreatedEmployeeDto employee);
        int UpdateEmployee(UpdatedEmployeeDto employee);
        bool DeleteEmployee(int id);
    }
}   

using IKEA.BLL.Dto.Department;
using IKEA.BLL.Dto.Employee;
using IKEA.BLL.Services.Employee;
using IKEA.DAL.Models.Employee;
using IKEA.PL.ViewModels.Department;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService,
        ILogger<EmployeeController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees(withTracking: false);
            return View(Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto createdEmployeeDto)
        {
            if (ModelState.IsValid) //Server Side Validation
            {
                try
                {
                    int result = _employeeService.CreateEmployee(createdEmployeeDto);
                    if (result > 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee can't be created");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                }
            }
            return View(createdEmployeeDto);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();
            var EmployeeDto = new UpdatedEmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Gender = Enum.Parse<EmployeeGender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                HiringDate = employee.HiringDate

            };
            return View(EmployeeDto);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdatedEmployeeDto updatedEmployeeDto)
        {
            if (!ModelState.IsValid) return View(updatedEmployeeDto);
            try
            {

                int result = _employeeService.UpdateEmployee(updatedEmployeeDto);
                if (result > 0)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(string.Empty, "Employee Can't be Updated");
            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(updatedEmployeeDto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            try
            {
                var deletedEmployee = _employeeService.DeleteEmployee(id);
                if (deletedEmployee)
                    return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can't be deleted");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return RedirectToAction("Index");
        }
    }
}

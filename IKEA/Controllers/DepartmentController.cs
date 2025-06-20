using IKEA.BLL.Dto;
using IKEA.BLL.Dto.Department;
using IKEA.BLL.Services.Departments;
using IKEA.PL.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
        }
        #region Department Index
        public IActionResult Index()
        {

            var departments = _departmentService.GetAllDepartments();

            return View(departments);
        }
        #endregion

        #region Create Department
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto createDepartmentDto)
        {
            if (ModelState.IsValid) //Server Side Validation
            {
                try
                {
                    int result = _departmentService.AddDepartment(createDepartmentDto);
                    if (result > 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can't be created");
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
            return View(createDepartmentDto);
        }
        #endregion

        #region Department Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null)
                return NotFound();
            return View(department);
        }
        #endregion

        #region Edit Department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null)
                return NotFound();
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.CreatedOn
            };
            return View(departmentViewModel);


        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, DepartmentEditViewModel departmentEditViewModel)
        {
            if (!ModelState.IsValid) return View(departmentEditViewModel);
            try
            {
                var updatedDepartment = new UpdateDepartmentDto()
                {
                    Id = id.Value,
                    Code = departmentEditViewModel.Code,
                    Name = departmentEditViewModel.Name,
                    Description = departmentEditViewModel.Description,
                    //DateOfCreation = departmentEditViewModel.DateOfCreation.Value
                };
                int result = _departmentService.UpdateDepartment(updatedDepartment);
                if (result > 0)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(string.Empty, "Department Can't be Updated");
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
            return View(departmentEditViewModel);
        }
        #endregion

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentService.GetDepartmentById(id.Value);
        //    if (department == null) return NotFound();
        //    return View(department);
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0 ) return BadRequest();
            try
            {
                bool deleted = _departmentService.DeleteDepartment(id);
                if (deleted) return RedirectToAction("Index");
                else 
                {
                    ModelState.AddModelError(string.Empty, "Department can't be deleted");
                    return RedirectToAction("Delete", new { id});
                }

            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction("Index");
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return RedirectToAction("Index");
                }
            }

        }
    }
}

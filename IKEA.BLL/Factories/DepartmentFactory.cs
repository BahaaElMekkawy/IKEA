using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Dto.Department;
using IKEA.DAL.Models;

namespace IKEA.BLL.Factories
{
    static public class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D) 
        {
            return new DepartmentDto()
            {
                Id = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value)
            };
        }


        public static DepartmentsDetailsDto ToDepartmentsDetailsDto(this Department department) 
        {
            return new DepartmentsDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value),
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                IsDeleted = department.IsDeleted
            };
        }

        public static Department ToDepartment(this CreateDepartmentDto createDepartmentDto)
        {
            return new Department()
            {
                Name = createDepartmentDto.Name,
                Code = createDepartmentDto.Code,
                Description = createDepartmentDto.Description,
                CreatedOn = createDepartmentDto.DateOfCreation,

            };
        }
        public static Department ToDepartment(this UpdateDepartmentDto updateDepartmentDto)
        {
            return new Department()
            {
                Id = updateDepartmentDto.Id,
                Name = updateDepartmentDto.Name,
                Code = updateDepartmentDto.Code,
                Description = updateDepartmentDto.Description,
                CreatedOn = updateDepartmentDto.DateOfCreation,

            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IKEA.BLL.Dto.Employee;
using IKEA.DAL.Models.Employee;

namespace IKEA.BLL.Profiles
{
    public class MappingsProfiles : Profile
    {
        public MappingsProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                        .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                        .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender));

            CreateMap<Employee, EmployeeDetailsDto>()
                       .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                       .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));

            CreateMap<CreatedEmployeeDto, Employee>()
                      .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                     .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}

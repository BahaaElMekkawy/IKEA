using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Data.Configurations
{
    public class EmployeeConfigurations :BaseEntityConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            //The Gender in Application Will Be int and in DataBase Will be A String 
            builder.Property(E => E.Gender)
                .HasConversion(
                    empGender => empGender.ToString(),
                    returnGender => (EmployeeGender)Enum.Parse(typeof(EmployeeGender), returnGender)
                );
            builder.Property(E => E.EmployeeType)
                .HasConversion(
                empType => empType.ToString(),
                returnType => (EmployeeType)Enum.Parse(typeof(EmployeeType), returnType)
                );

            base.Configure(builder);
        }
    }
}

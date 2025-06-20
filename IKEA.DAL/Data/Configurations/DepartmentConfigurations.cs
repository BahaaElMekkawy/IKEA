using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Data.Configurations
{
    public class DepartmentConfigurations : BaseEntityConfigurations<Department> , IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");

            builder.HasMany(D => D.Employees).WithOne(E => E.Department)
                .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);

        }
    }
}

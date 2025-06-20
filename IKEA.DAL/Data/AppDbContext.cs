using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IKEA.DAL.IdentityEntities;
using IKEA.DAL.Models;
using IKEA.DAL.Models.Employee;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,string>//DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
         
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=IKEA;Integrated Security=true;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

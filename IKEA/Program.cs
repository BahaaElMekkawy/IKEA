using IKEA.BLL.Profiles;
using IKEA.BLL.Services.Departments;
using IKEA.BLL.Services.Employee;
using IKEA.DAL;
using IKEA.DAL.Data;
using IKEA.DAL.Data.Repositories.Classes;
using IKEA.DAL.Data.Repositories.Interfaces;
using IKEA.DAL.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IKEA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            //builder.Services.AddAutoMapper(typeof(MappingsProfiles).Assembly); Can be in an other Assembly and it will not work
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingsProfiles()));

            //builder.Services.AddPresistenceServices(builder.Configuration);

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()//Configure the user and role calss to use 
                .AddEntityFrameworkStores<AppDbContext>() // Configure where the tables will be 
                //Repository for users
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, AppDbContext,string>>()
                //Repository for Role
                .AddRoleStore<RoleStore< ApplicationRole, AppDbContext,string>>();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

using IKEA.DAL.Data.Repositories.Interfaces;
using IKEA.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Data.Repositories.Classes
{
    public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext = dbContext;// => at fitst is null so we need an object from it to use it 

        public int AddDepartment(Department department)
        {
             _dbContext.Departments.Add(department); 
            return _dbContext.SaveChanges(); 
        }

        public int DeleteDepartment(Department department)
        {
           _dbContext.Departments.Remove(department); // change status Only 
            return _dbContext.SaveChanges();          //Updtae the database
        }

        public Department GetDepartmentById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public IEnumerable<Department> GetDepartments(bool withracking = false)
        {
            if(withracking)
                return _dbContext.Departments.ToList();
            return _dbContext.Departments.AsNoTracking().ToList();
        }

        public int UpdateDepartment(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();

        }
    }
}

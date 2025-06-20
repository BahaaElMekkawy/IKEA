using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Data.Repositories.Interfaces;
using IKEA.DAL.Models;
using IKEA.DAL.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Data.Repositories.Classes
{
    public class EmployeeRepository(AppDbContext _dbContext) : GenericRepository<Employee>(_dbContext), IEmployeeRepository
    {
        // لما اجي اعمل اوبجت منه هيروح يعمل اوبجت من الكونتكست ويبعته لل ريبو عشان يستخدمه في كده انا مش هحتاج اعرف السيرفس ان الجينيرك ريبو هيتحقنله اوبجت من الكونتكست انا هبعتهوله لما اجي اورث منه 
        public IQueryable<Employee> GetEmployeeByAdress(string adress)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;
using IKEA.DAL.Models.Employee;

namespace IKEA.DAL.Data.Repositories.Interfaces
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(bool withtracking = false);
        T GetById(int id);
        int Add(T employee);
        int Update(T employee);
        int Delete(T employee);
    }
}

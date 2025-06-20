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
    public class GenericRepository<T>(AppDbContext _dbContext) : IGenericRepository<T> where T : BaseEntity
    {
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            //_dbContext.Add(entity); // It will add accordingto the type of the entity
            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);       // change status Only 
            return _dbContext.SaveChanges();          //Updtae the database
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll(bool withracking = false)
        {
            if (withracking)
                return _dbContext.Set<T>().Where(T => T.IsDeleted == false).ToList();
            return _dbContext.Set<T>().Where(T => T.IsDeleted == false).AsNoTracking().ToList();
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();

        }
    }
}

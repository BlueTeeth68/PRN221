using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StudentDBContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            this._context = new StudentDBContext();
            //Create a db set for T class
            this._dbSet = _context.Set<T>();
        }

        public GenericRepository(StudentDBContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T entity = this._dbSet.Find(id);
            if (entity != null)
            {
                this._dbSet.Remove(entity);
                Save();
            }
        }

        public bool ExistById(object id)
        {
            return this._dbSet.Find(id) != null;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> GetAllPaginate(int page, int size)
        {
            return this._dbSet.Skip((page - 1) * size).Take(size).ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T obj)
        {
            _dbSet.Add(obj);
            Save();
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void Update(T obj)
        {
            this._dbSet.Attach(obj);
            this._context.Entry(obj).State = EntityState.Modified;
            Save();
        }
    }
}

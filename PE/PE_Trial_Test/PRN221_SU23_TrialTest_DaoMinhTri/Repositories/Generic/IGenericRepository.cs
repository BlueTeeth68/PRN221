using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        T GetById(Object id);
        IEnumerable<T> GetAll();
        void DeleteById(Object id);
        void Save();
    }
}

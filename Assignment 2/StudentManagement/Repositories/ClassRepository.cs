using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public IEnumerable<Class> FindByName(string name)
        {
            return _dbSet.Where(c => c.ClassName.ToLower().Contains(name.ToLower()));
        }
    }
}

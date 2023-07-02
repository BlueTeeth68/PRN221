using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        IEnumerable<Class> FindByName(string name);
    }
}

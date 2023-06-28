using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ClassMemberRepository : GenericRepository<ClassMember>, IClassMemberRepository
    {
        public IEnumerable<ClassMember> FindByName(string name)
        {
            return _dbSet.Where(cm => (cm.FirstName + cm.LastName).ToLower().Contains(name.ToLower())).ToList();
        }

        public bool ExistById(object id)
        {
            return this._dbSet.Any(o => o.MemberId == id);
        }

    }
}

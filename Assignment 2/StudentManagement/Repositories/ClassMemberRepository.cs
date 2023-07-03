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

        /*public IEnumerable<ClassMember> GetAllWithPaginate(int page, int pageSize)
        {
            return _dbSet.Skip((page - 1) * pageSize)
                .Take(pageSize);
        }*/

        public int GetAllTotalPage(int pageSize)
        {
            int total = GetTotalElement();
            return (int)Math.Ceiling((double)total / pageSize);
        }

        public int GetTotalElement()
        {
            return _dbSet.Count();
        }

        public PageResult<ClassMember> GetAllWithPaginate(int pageNumber, int pageSize)
        {
            PageResult<ClassMember> result = new PageResult<ClassMember>();
            result.Results = _dbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            int total = GetTotalElement();
            result.TotalPage = (int)Math.Ceiling((double)total / pageSize);
            return result;
        }

        public PageResult<ClassMember> FindByName(string name, int pageNumber, int pageSize)
        {
            PageResult<ClassMember> result = new PageResult<ClassMember>();
            IEnumerable<ClassMember> classMembers = _dbSet.Where(cm => (cm.FirstName + cm.LastName).ToLower().Contains(name.ToLower()));
            int total = classMembers.ToList().Count();
            result.TotalPage = (int)Math.Ceiling((double)total / pageSize);

            result.Results = classMembers
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return result;
        }
    }
}

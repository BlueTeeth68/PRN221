using BusinessObjects.Models;
using Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CorrespondingAuthors
{
    public class CorrespondingAuthorRepository : GenericRepository<CorrespondingAuthor>, ICorrespondingAuthorRepository
    {
        public PageResult<CorrespondingAuthor> GetAuthorsPaginate(int pageNumber, int pageSize)
        {
            PageResult<CorrespondingAuthor> result = new PageResult<CorrespondingAuthor>();
            result.Result = _dbSet.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            int total = _dbSet.ToList().Count;
            result.TotalPage = (int)Math.Ceiling((double)total / pageSize);
            return result;
        }

        public PageResult<CorrespondingAuthor> GetByNameOrSkillPaginate(string query, int pageNumber, int pageSize)
        {
            if (query == null || query.Trim().Equals(""))
            {
                return null;
            }
            PageResult<CorrespondingAuthor> result = new PageResult<CorrespondingAuthor>();
            IEnumerable<CorrespondingAuthor> list = _dbSet.Where(a => (a.Skills.ToLower().Contains(query.Trim().ToLower()) || a.AuthorName.ToLower().Contains(query.Trim().ToLower())));
            result.Result = list.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int total = list.Count();
            result.TotalPage = (int)Math.Ceiling((double)total / pageSize);
            return result;
        }
    }
}

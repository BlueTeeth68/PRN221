using BusinessObjects.Models;
using Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CorrespondingAuthors
{
    public interface ICorrespondingAuthorRepository : IGenericRepository<CorrespondingAuthor>
    {
        PageResult<CorrespondingAuthor> GetAuthorsPaginate(int pageNumber, int pageSize);

        PageResult<CorrespondingAuthor> GetByNameOrSkillPaginate(String query, int pageNumber, int pageSize);
    }
}

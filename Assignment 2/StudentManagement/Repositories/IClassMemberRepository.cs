using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IClassMemberRepository:IGenericRepository<ClassMember>
    {

        IEnumerable<ClassMember> FindByName(string name);
        PageResult<ClassMember> FindByName(string name, int pageNumber, int pageSize);

        PageResult<ClassMember> GetAllWithPaginate(int pageNumber, int pageSize);

        int GetAllTotalPage(int pageSize);
        int GetTotalElement();
    }
}

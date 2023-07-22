using BusinessObjects.Models;
using Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.MemberAccounts
{
    public interface IMemberAccountRepository : IGenericRepository<MemberAccount>
    {

        MemberAccount Login(String memberId, String password);
    }
}

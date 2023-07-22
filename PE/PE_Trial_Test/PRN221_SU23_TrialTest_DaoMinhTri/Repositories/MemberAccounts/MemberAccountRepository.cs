using BusinessObjects.Models;
using Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.MemberAccounts
{
    public class MemberAccountRepository : GenericRepository<MemberAccount>, IMemberAccountRepository
    {
        public MemberAccount Login(string memberId, string password)
        {
            return _dbSet.SingleOrDefault(ma => (ma.MemberId.ToLower().Equals(memberId.ToLower()) && ma.MemberPassword.Equals(password)));
        }
    }
}

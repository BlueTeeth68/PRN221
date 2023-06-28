using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        User FindByUsername(string username);
        bool ExistByUsername(string username);
        User FindByUserNameAndPassword(string username, string password);

    }
}

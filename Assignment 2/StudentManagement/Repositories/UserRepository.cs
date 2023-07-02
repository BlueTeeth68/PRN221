using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public bool ExistByUsername(string username)
        {
            return _dbSet.Any(u => u.Username.ToLower().Equals(username.ToLower()));
        }

        public User FindByUsername(string username)
        {
            return _dbSet.SingleOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
        }

        public User FindByUserNameAndPassword(string username, string password)
        {
            return _dbSet.SingleOrDefault(u => u.Username.ToLower().Equals(username.ToLower()) && u.Password.Equals(password));
        }
    }
}

using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(StudentDBContext dBContext) : base(dBContext)
        {
        }
    }
}

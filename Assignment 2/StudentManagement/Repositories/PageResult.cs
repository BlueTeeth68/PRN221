using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public  class PageResult <T> where T : class
    {
        public int TotalPage { get; set; }
        public IEnumerable<T> Results { get; set;}

    }
}

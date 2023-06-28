using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Class
    {
        public Class()
        {
            Members = new HashSet<ClassMember>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<ClassMember> Members { get; set; }
    }
}

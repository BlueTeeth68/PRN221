using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class ClassMember
    {
        public ClassMember()
        {
            Classes = new HashSet<Class>();
        }

        public string MemberId { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Role { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}

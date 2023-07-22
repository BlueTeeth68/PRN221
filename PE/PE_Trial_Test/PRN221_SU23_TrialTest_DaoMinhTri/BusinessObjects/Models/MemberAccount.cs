using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class MemberAccount
    {
        public string MemberId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string? MemberPassword { get; set; }
        public int? MemberRole { get; set; }
    }
}

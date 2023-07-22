using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class CorrespondingAuthor
    {
        public string AuthorId { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public DateTime AuthorBirthday { get; set; }
        public string Bio { get; set; } = null!;
        public string? Skills { get; set; }
        public int? InstitutionId { get; set; }

        public virtual InstitutionInformation? Institution { get; set; }
    }
}

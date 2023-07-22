using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class InstitutionInformation
    {
        public InstitutionInformation()
        {
            CorrespondingAuthors = new HashSet<CorrespondingAuthor>();
        }

        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string TelephoneNumber { get; set; } = null!;
        public string? InstitutionDescription { get; set; }

        public virtual ICollection<CorrespondingAuthor> CorrespondingAuthors { get; set; }
    }
}

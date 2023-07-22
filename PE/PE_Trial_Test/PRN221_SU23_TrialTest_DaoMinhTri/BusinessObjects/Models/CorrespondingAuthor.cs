using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public partial class CorrespondingAuthor
    {
        [Required(ErrorMessage = "Id is required")]
        [DataType(DataType.Text)]
        public string AuthorId { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression("[A-Z]([a-z0-9]*)(( [A-Z]([a-z0-9]*))*)", ErrorMessage = "Each word of name must begin with Capital letter.")]
        [Required(ErrorMessage = "AuthorName is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Name must be from 6 to 100 character")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "AuthorBirthday is required")]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "1901-01-01", "2023-12-31", ErrorMessage = "Year must be between 1901 and 2023")]
        public DateTime AuthorBirthday { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Skills is required")]
        public string? Skills { get; set; }

        [Required(ErrorMessage = "InstitutionId is required")]
        public int? InstitutionId { get; set; }

        public virtual InstitutionInformation? Institution { get; set; }
    }
}

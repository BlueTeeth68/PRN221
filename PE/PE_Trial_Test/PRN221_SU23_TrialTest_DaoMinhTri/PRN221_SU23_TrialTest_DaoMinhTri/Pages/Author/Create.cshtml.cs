using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace AuthorInstitution_DaoMinhTri.Pages.Author
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.AuthorInstitution2023DBContext _context;

        public CreateModel(BusinessObjects.Models.AuthorInstitution2023DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstitutionId"] = new SelectList(_context.InstitutionInformations, "InstitutionId", "Area");
            return Page();
        }

        [BindProperty]
        public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CorrespondingAuthors == null || CorrespondingAuthor == null)
            {
                return Page();
            }

            _context.CorrespondingAuthors.Add(CorrespondingAuthor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

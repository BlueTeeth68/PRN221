using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.CorrespondingAuthors;
using Repositories.InstitutionInformations;

namespace AuthorInstitution_DaoMinhTri.Pages.Author
{
    public class EditModel : PageModel
    {
        private readonly ICorrespondingAuthorRepository repository;
        private readonly IInstitutionInformationRepository subRepository;


        public EditModel(ICorrespondingAuthorRepository repository, IInstitutionInformationRepository subRepository)
        {
            this.repository = repository;
            this.subRepository = subRepository;
        }

        [BindProperty]
        public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {

            //check login
            String fullName = HttpContext.Session.GetString("FullName");
            if (fullName == null)
            {
                return RedirectToPage("/Login");
            }


            if (id == null)
            {
                return NotFound();
            }

            var correspondingauthor = repository.GetById(id);
            if (correspondingauthor == null)
            {
                return NotFound();
            }
            CorrespondingAuthor = correspondingauthor;
            ViewData["InstitutionId"] = new SelectList(subRepository.GetAll().ToList(), "InstitutionId", "Area");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repository.Update(CorrespondingAuthor);

            return RedirectToPage("./Index");
        }


    }
}

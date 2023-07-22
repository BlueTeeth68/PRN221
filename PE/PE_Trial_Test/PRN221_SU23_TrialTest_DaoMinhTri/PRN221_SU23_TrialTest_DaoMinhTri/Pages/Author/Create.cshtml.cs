using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using System.ComponentModel.DataAnnotations;
using Repositories.CorrespondingAuthors;
using Repositories.InstitutionInformations;

namespace AuthorInstitution_DaoMinhTri.Pages.Author
{
    public class CreateModel : PageModel
    {
        private readonly ICorrespondingAuthorRepository repository;
        private readonly IInstitutionInformationRepository institutionRepository;

        public CreateModel(ICorrespondingAuthorRepository repository, IInstitutionInformationRepository institutionRepository)
        {
            this.repository = repository;
            this.institutionRepository = institutionRepository;
        }

        public IActionResult OnGet()
        {
            //check login
            String fullName = HttpContext.Session.GetString("FullName");
            if (fullName == null)
            {
                return RedirectToPage("/Login");
            }

            //get data for combo box
            ViewData["InstitutionId"] = new SelectList(institutionRepository.GetAll(), "InstitutionId", "Area");
            return Page();
        }

        [BindProperty]
        public CorrespondingAuthor CorrespondingAuthor { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || CorrespondingAuthor == null)
            {
                return Page();
            }

            repository.Add(CorrespondingAuthor);

            return RedirectToPage("./Index");
        }
    }


}

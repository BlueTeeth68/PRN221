using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.CorrespondingAuthors;

namespace AuthorInstitution_DaoMinhTri.Pages.Author
{
    public class DeleteModel : PageModel
    {
        private readonly ICorrespondingAuthorRepository repository;



        public DeleteModel(ICorrespondingAuthorRepository repository)
        {
            this.repository = repository;
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
            else
            {
                CorrespondingAuthor = correspondingauthor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null )
            {
                return NotFound();
            }
            repository.DeleteById(id);

            return RedirectToPage("./Index");
        }
    }
}

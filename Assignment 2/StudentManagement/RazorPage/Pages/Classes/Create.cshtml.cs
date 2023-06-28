using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;

namespace RazorPage.Pages.Classes
{
    public class CreateModel : PageModel
    {
        private readonly IClassRepository classRepository;

        public CreateModel(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Class Class { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Class == null)
            {
                return Page();
            }

            classRepository.Insert(Class);

            return RedirectToPage("./Index");
        }
    }
}

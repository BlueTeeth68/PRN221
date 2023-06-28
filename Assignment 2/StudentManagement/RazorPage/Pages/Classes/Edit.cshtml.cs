using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace RazorPage.Pages.Classes
{
    public class EditModel : PageModel
    {
        private readonly IClassRepository classRepository;

        public EditModel(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        [BindProperty]
        public Class Class { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classEntity = classRepository.GetById(id);
            if (classEntity == null)
            {
                return NotFound();
            }
            Class = classEntity;
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

            classRepository.Update(Class);

            return RedirectToPage("./Index");
        }
    }
}

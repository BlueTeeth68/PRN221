using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace RazorPage.Pages.Classes
{
    public class DeleteModel : PageModel
    {
        private readonly IClassRepository _classRepository;

        public DeleteModel(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [BindProperty]
        public Class Class { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classEntity = _classRepository.GetById(id);

            if (classEntity == null)
            {
                return NotFound();
            }
            else
            {
                Class = classEntity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var classEntity = _classRepository.GetById(id);

            if (classEntity != null)
            {
                Class = classEntity;
                _classRepository.Delete(Class.ClassId);
            }

            return RedirectToPage("./Index");
        }
    }
}

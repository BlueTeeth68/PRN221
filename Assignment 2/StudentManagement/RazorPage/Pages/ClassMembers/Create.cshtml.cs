using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;

namespace RazorPage.Pages.ClassMembers
{
    public class CreateModel : PageModel
    {
        private readonly IClassMemberRepository classMemberRepository;

        public CreateModel(IClassMemberRepository classMemberRepository)
        {
            this.classMemberRepository = classMemberRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClassMember ClassMember { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || ClassMember == null)
            {
                return Page();
            }

            classMemberRepository.Insert(ClassMember);

            return RedirectToPage("./Index");
        }
    }
}

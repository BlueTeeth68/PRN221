using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace RazorPage.Pages.ClassMembers
{
    public class DeleteModel : PageModel
    {
        private readonly IClassMemberRepository classMemberRepository;

        public DeleteModel(IClassMemberRepository classMemberRepository)
        {
            this.classMemberRepository = classMemberRepository;
        }

        [BindProperty]
        public ClassMember ClassMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classMember = classMemberRepository.GetById(id);

            if (classMember == null)
            {
                return NotFound();
            }
            else
            {
                ClassMember = classMember;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var classmember = classMemberRepository.GetById(id);

            if (classmember != null)
            {
                ClassMember = classmember;
                classMemberRepository.Delete(ClassMember.MemberId);
            }

            return RedirectToPage("./Index");
        }
    }
}

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

namespace RazorPage.Pages.ClassMembers
{
    public class EditModel : PageModel
    {
        private readonly IClassMemberRepository classMemberRepository;

        public EditModel(IClassMemberRepository classMemberRepository)
        {
            this.classMemberRepository = classMemberRepository;
        }

        public string? Message { get; set; }
        public string? ErrorMessage { get; set; }
        [BindProperty]
        public ClassMember ClassMember { get; set; } = default!;

        public  IActionResult OnGet(string id)
        {
            if (id == null || classMemberRepository.GetAll() == null)
            {
                return NotFound();
            }

            var classMember = classMemberRepository.GetById(id);
            if (classMember == null)
            {
                return NotFound();
            }
            ClassMember = classMember;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public  IActionResult OnPost()
        {
            ErrorMessage = null;
            Message = null;
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Error input data";
                return Page();
            }

            if (ClassMemberExists(ClassMember.MemberId))
            {
                Console.WriteLine("ClassMember before update: ");
                Console.WriteLine(ClassMember.Gender);
                Console.WriteLine("Call update function:");
                classMemberRepository.Update(ClassMember);
                
                Message = "Update Successfully";
                return Page();
            } else
            {
                ErrorMessage = "Class member does not exist.";
                return Page();
            }
        }

        private bool ClassMemberExists(string id)
        {
            return classMemberRepository.ExistById(id);
        }
    }
}

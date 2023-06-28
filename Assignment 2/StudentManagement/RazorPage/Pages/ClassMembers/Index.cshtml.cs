using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Microsoft.Build.Framework;
using Repositories;

namespace RazorPage.Pages.ClassMembers
{
    public class IndexModel : PageModel
    {
        private readonly IClassMemberRepository classMemberRepository;


        [BindProperty]
        public string? Query { get; set; }
        public string Message { get; set; }

        public IndexModel(IClassMemberRepository classMemberRepository)
        {
            this.classMemberRepository = classMemberRepository;
        }

        public IList<ClassMember> ClassMember { get; set; } = default!;

        public void OnGet()
        {
            if (Query == null)
            {
                ClassMember = classMemberRepository.GetAll().ToList();
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = null;
                if (Query == null || Query.Trim().Equals(""))
                {
                    ClassMember = classMemberRepository.GetAll().ToList();
                    return Page();
                }
                else
                {
                    ClassMember = classMemberRepository.FindByName(Query).ToList();
                    return Page();
                }
            }
            else
            {
                Message = "Error when Input data.";
                return Page();
            }
        }
    }
}

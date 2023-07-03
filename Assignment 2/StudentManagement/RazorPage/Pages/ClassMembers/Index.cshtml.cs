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
using System.ComponentModel.DataAnnotations;

namespace RazorPage.Pages.ClassMembers
{
    public class IndexModel : PageModel
    {
        private readonly IClassMemberRepository classMemberRepository;
        private readonly int pageSize = 20;


        [BindProperty]
        [DataType(DataType.Text)]
        public string? Query { get; set; }
        public string Message { get; set; }

        public int Page { get; set; } = 1;
        public int TotalPage { get; set; }

        public IndexModel(IClassMemberRepository classMemberRepository)
        {
            this.classMemberRepository = classMemberRepository;
        }

        public IList<ClassMember> ClassMember { get; set; } = default!;

        public void OnGet(int? pageNumber, string? query)
        {
            Query = query ?? Query;
            if (Query == null || Query.Trim().Equals(""))
            {
                Page = pageNumber ?? 1;
                PageResult<ClassMember> result = classMemberRepository.GetAllWithPaginate(Page, pageSize);
                TotalPage = result.TotalPage;
                Console.WriteLine($"pageNumber: {pageNumber}");
                Console.WriteLine($"Total page: {TotalPage}");
                ClassMember = result.Results.ToList();
            } else
            {
                Page = pageNumber ?? 1;
                PageResult<ClassMember> result = classMemberRepository.FindByName(Query, Page, pageSize);
                TotalPage = result.TotalPage;
                ClassMember = result.Results.ToList();
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = null;
                if (Query == null || Query.Trim().Equals(""))
                {
                    PageResult<ClassMember> result = classMemberRepository.GetAllWithPaginate(Page, pageSize);
                    TotalPage = result.TotalPage;
                    ClassMember = result.Results.ToList();
                    return Page();
                }
                else
                {
                    PageResult<ClassMember> result = classMemberRepository.FindByName(Query, Page, pageSize);
                    TotalPage = result.TotalPage;
                    ClassMember = result.Results.ToList();
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

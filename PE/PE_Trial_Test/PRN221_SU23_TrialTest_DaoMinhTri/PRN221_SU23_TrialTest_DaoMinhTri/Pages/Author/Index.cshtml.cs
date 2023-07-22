using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.CorrespondingAuthors;
using System.ComponentModel.DataAnnotations;

namespace AuthorInstitution_DaoMinhTri.Pages.Author
{
    public class IndexModel : PageModel
    {
        //private readonly BusinessObjects.Models.AuthorInstitution2023DBContext _context;
        private readonly ICorrespondingAuthorRepository repository;
        const int pageSize = 4;

        public int PageNumber { get; set; } = 1;
        public int TotalPage { get; set; } = 0;

        [BindProperty]
        [DataType(DataType.Text)]
        public String? Query { get; set; }

        public IndexModel(ICorrespondingAuthorRepository repository)
        {
            this.repository = repository;
        }

        public IList<CorrespondingAuthor> CorrespondingAuthor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? pageNumber, string? query)
        {
            //check login
            String fullName = HttpContext.Session.GetString("FullName");
            if (fullName == null)
            {
                return RedirectToPage("/Login");
            }

            Query = query ;
            if (Query == null || Query.Trim().Equals(""))
            {
                //get list pagination
                PageNumber = pageNumber ?? 1;

                var result = repository.GetAuthorsPaginate(PageNumber, pageSize);
                CorrespondingAuthor = result.Result.ToList();

                TotalPage = result.TotalPage;

                return Page();
            } else
            {
                //get list pagination
                PageNumber = pageNumber ?? 1;

                var result = repository.GetByNameOrSkillPaginate(Query, PageNumber, pageSize);
                CorrespondingAuthor = result.Result.ToList();

                TotalPage = result.TotalPage;

                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Query != null && !Query.Trim().Equals(""))
                {
                    var result = repository.GetByNameOrSkillPaginate(Query, 1, pageSize);
                    CorrespondingAuthor = result.Result.ToList();

                    TotalPage = result.TotalPage;
                    return Page();
                }
                else
                {
                    var result = repository.GetAuthorsPaginate(1, pageSize);
                    CorrespondingAuthor = result.Result.ToList();

                    TotalPage = result.TotalPage;

                    return Page();
                }
            }
            return Page();
        }
    }
}

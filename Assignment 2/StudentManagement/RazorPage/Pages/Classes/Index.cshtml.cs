using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace RazorPage.Pages.Classes
{
    public class IndexModel : PageModel
    {
        private readonly IClassRepository classRepository;

        [BindProperty]
        [DataType(DataType.Text)]
        public string? Query { get; set; }

        public IndexModel(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public IList<Class> Class { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Class = classRepository.GetAll().ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Query == null || Query.Trim().Equals(""))
                {
                    Class = classRepository.GetAll().ToList();
                    return Page();
                }
                else
                {
                    Class = classRepository.FindByName(Query).ToList();
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}

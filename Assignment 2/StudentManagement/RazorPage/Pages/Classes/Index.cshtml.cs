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
    public class IndexModel : PageModel
    {
        private readonly IClassRepository classRepository;

        public IndexModel(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public IList<Class> Class { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Class = classRepository.GetAll().ToList();
        }
    }
}

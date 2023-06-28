using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace RazorPage.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;
public IndexModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = userRepository.GetAll().ToList();
        }
    }
}

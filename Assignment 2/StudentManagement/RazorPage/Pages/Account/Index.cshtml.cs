using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace RazorPage.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;
        public string Username { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public string Role { get; set; }

        public IndexModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void OnGet()
        {
            Username = HttpContext.Session.GetString("username");
            User user = userRepository.FindByUsername(Username);
            FullName = user.FullName;
            AvatarUrl = user.AvatarUrl;
            Role = user.Role;
        }
    }

}

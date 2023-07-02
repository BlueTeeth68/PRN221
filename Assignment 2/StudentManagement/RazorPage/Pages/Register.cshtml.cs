using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace RazorPage.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly IUserRepository userRepository;

        [BindProperty]
        public UserRegister UserRegister { get; set; }

        public string Message { get; set; }

        public RegisterModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void OnGet(UserRegister userRegister)
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                if(userRepository.ExistByUsername(UserRegister.Username))
                {
                    Message = "This user has been existed!";
                    return Page();
                } else
                {
                    Message = null;
                    User user = new User();
                    user.Username = UserRegister.Username;
                    user.FullName = UserRegister.FullName;
                    user.Password = UserRegister.Password;
                    user.Role = "User";
                    user.AvatarUrl = "/Asset/Images/avatar.jpg";

                    userRepository.Insert(user);

                    HttpContext.Session.SetString("fullName", user.FullName);
                    HttpContext.Session.SetString("username", user.Username);
                    HttpContext.Session.SetString("role", user.Role);
                    HttpContext.Session.SetString("avatarUrl", user.AvatarUrl);
                    return RedirectToPage("./Account/Index");
                }
            } else
            {
                Message = null;
                return Page();
            }
        }
    }

    public class UserRegister
    {
        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Full name is required")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

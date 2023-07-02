using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace RazorPage.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository userRepository;

        [BindProperty]
        public Credential Credential { get; set; }

        public string Message { get; set; }

        public LoginModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = userRepository.FindByUserNameAndPassword(Credential.Username, Credential.Password);
                if (user == null)
                {
                    Message = "Incorrect username or password";
                    return Page();
                }
                else
                {
                    Message = null;
                    HttpContext.Session.SetString("fullName", user.FullName);
                    HttpContext.Session.SetString("username", user.Username);
                    HttpContext.Session.SetString("role", user.Role);
                    HttpContext.Session.SetString("avatarUrl", user.AvatarUrl);
                    if (user.Role == "Admin")
                    {
                        return RedirectToPage("./Classes/Index");
                    } else
                    {
                        return RedirectToPage("./Account/Index");
                    }
                }
            }
            else
            {
                Message = null;
                return Page();
            }
        }

    }

    public class Credential
    {

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required.")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }


}

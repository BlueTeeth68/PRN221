using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Repositories.MemberAccounts;
using System.ComponentModel.DataAnnotations;

namespace AuthorInstitution_DaoMinhTri.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IMemberAccountRepository memberAccountRepository;



        public String Message { get; set; }
        [BindProperty]
        public Credential Credential { get; set; }

        public LoginModel(IMemberAccountRepository memberAccountRepository)
        {
            this.memberAccountRepository = memberAccountRepository;
        }

        public IActionResult OnGet()
        {
            //Check session here
            var fullName = HttpContext.Session.GetString("FullName");
            if (fullName != null)
            {
                return RedirectToPage("/Author/Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var member = memberAccountRepository.Login(Credential.MemberId, Credential.Password);
                if (member == null || member?.MemberRole != 1)
                {
                    Message = "You do not have permission to do this function";
                    return Page();
                }
                else
                {
                    Message = null;
                    HttpContext.Session.SetString("FullName", member.FullName);
                    HttpContext.Session.SetString("Role", member.MemberRole.ToString());
                    return RedirectToPage("/Author/Index");
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
        [Display(Name = "Member Id")]
        [Required(ErrorMessage = "Member id is required")]
        [DataType(DataType.Text)]
        public string MemberId { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

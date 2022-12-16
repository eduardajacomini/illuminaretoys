using IlluminareToys.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace IlluminareToys.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginPage : PageModel
    {
        private readonly IToastNotification _toastNotification;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginPage(SignInManager<User> signInManager,
                         UserManager<User> userManager,
                         IToastNotification toastNotification)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Display(Name = "Email")]
            [Required(ErrorMessage = "Email obrigatório.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Senha obrigatória.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Lembrar-me")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {

                var userName = Input.Email;

                if (!IsValidEmail(Input.Email))
                {
                    ModelState.AddModelError(string.Empty, "Credenciais inválidas.");
                    return Page();
                }

                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user != null)
                {
                    userName = user.UserName;
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(userName, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Credenciais inválidas.");
                    return Page();
                }

                _toastNotification.AddSuccessToastMessage($"Bem-vindo, {user.FirstName}");
                return LocalRedirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                var mailAddress = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

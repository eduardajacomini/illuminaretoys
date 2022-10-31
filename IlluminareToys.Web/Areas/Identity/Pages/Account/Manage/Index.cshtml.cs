using IlluminareToys.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace IlluminareToys.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string UserNameChangeLimitMessage { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Nome")]
            public string FirstName { get; set; }
            [Display(Name = "Sobrenome")]
            public string LastName { get; set; }
            [Display(Name = "Usuário")]
            public string Username { get; set; }
            [Phone]
            [Display(Name = "Telefone")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Foto de perfil")]
            public byte[] ProfilePicture { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível encontrar o usuário com ID '{_userManager.GetUserId(User)}'.");
            }
            UserNameChangeLimitMessage = $"Você pode mudar seu usuário mais {user.UsernameChangeLimit} vezes.";
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível encontrar o usuário com ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Erro ao definir número de telefone.";
                    return RedirectToPage();
                }
            }
            var firstName = user.FirstName;
            var lastName = user.LastName;
            if (Input.FirstName != firstName)
            {

                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }
            if (user.UsernameChangeLimit > 0)
            {
                if (Input.Username != null)
                {
                    if (Input.Username != user.UserName)
                    {
                        var userNameExists = await _userManager.FindByNameAsync(Input.Username);
                        if (userNameExists != null)
                        {
                            StatusMessage = "Usuário já existente. Informe um diferente.";
                            return RedirectToPage();
                        }

                        var setUserName = await _userManager.SetUserNameAsync(user, Input.Username);
                        if (!setUserName.Succeeded)
                        {
                            StatusMessage = "Erro ao definir o usuário.";
                            return RedirectToPage();
                        }
                        else
                        {
                            user.UsernameChangeLimit -= 1;
                            await _userManager.UpdateAsync(user);
                        }
                    }
                }

            }

            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                await using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Seu perfil foi atualizado com sucesso!";
            return RedirectToPage();
        }
    }
}

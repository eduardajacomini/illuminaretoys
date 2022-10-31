using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IlluminareToys.Web.Areas.Identity.Pages.Account
{
    public class RolesModel : PageModel
    {
        public List<IdentityRole<Guid>> Roles { get; set; }

        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public RolesModel(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
            Roles = new List<IdentityRole<Guid>>();
        }
        public async Task OnGet()
        {
            Roles = await _roleManager.Roles.ToListAsync();
        }
        public async Task OnPostAsync(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid>(roleName.Trim()));
            }
            await OnGet();
        }
    }
}

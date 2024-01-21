using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApp.Components.About
{
    [ViewComponent(Name = "ProfileList")]
    public class MessageList : ViewComponent
    {
        private readonly UserManager<IdentityUser> _userManager;

        public MessageList(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);

            return View(user);
        }
    }
}

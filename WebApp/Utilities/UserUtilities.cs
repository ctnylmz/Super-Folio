// UserUtilities.cs
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Dev_Folio.Utilities
{
    public static class UserUtilities
    {
        public static async Task EnsureDefaultUserCreated(UserManager<IdentityUser> userManager)
        {
            var allUsers = userManager.Users;

            if (!allUsers.Any())
            {
                var Email = "admin@gmail.com";

                IdentityUser user = new IdentityUser
                {
                    UserName = Email,
                    Email = Email,
                    PhoneNumber = Email,
                };

                IdentityResult result = await userManager.CreateAsync(user, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}

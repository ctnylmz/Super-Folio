using Microsoft.AspNetCore.Identity;

namespace WebApp.Utilities
{
    public class DefaultUserUtilities
    {
        public static async Task CreateUser(UserManager<IdentityUser> userManager)
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

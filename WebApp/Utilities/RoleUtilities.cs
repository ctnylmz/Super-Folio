using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Dev_Folio.Utilities
{
    public class RoleUtilities
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleUtilities(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task EnsureRolesCreated()
        {
            string[] rolesToCreate = { "Admin" };

            foreach (var roleName in rolesToCreate)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    var newRole = new IdentityRole { Name = roleName };
                    await _roleManager.CreateAsync(newRole);
                }
            }
        }
    }
}

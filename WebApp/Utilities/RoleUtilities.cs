﻿// RoleUtilities.cs
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Dev_Folio.Utilities
{
    public static class RoleUtilities
    {
        public static async Task EnsureRolesCreated(RoleManager<IdentityRole> roleManager)
        {
            // Admin ve User rollerini oluştur
            string[] defaultRoles = { "Admin", "User" };

            foreach (var roleName in defaultRoles)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}

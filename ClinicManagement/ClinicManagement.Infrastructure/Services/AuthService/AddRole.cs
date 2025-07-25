using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Domain.ModelsAutentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.Service.Identity
{
    public class AddRole : IAddRole
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AddRole(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ResponseIdentityCreate> AdicionarRoles(string userEmail, string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                return new ResponseIdentityCreate { Status = "404", Message = $"Role {roleName} not found." };
            }

            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user is not null)
            {
                var roleAdd = await _userManager.AddToRoleAsync(user, roleName);

                if (roleAdd.Succeeded)
                {
                    return new ResponseIdentityCreate { Status = "200", Message = $"User {user.Email} added to role {roleName} successfully." };
                }
                else
                {
                    return new ResponseIdentityCreate { Status = "400", Message = "Error adding user to role." };
                }
            }
            return new ResponseIdentityCreate { Status = "404", Message = $"User {userEmail} not found." };
        }
    }
}

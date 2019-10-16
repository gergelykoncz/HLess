using HLess.Logic.Wrappers.Interfaces;
using HLess.Models.Entities;
using HLess.Models.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;

namespace HLess.Logic.Wrappers
{
    public class UserManagerWrapper : IUserManagerWrapper
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserManagerWrapper(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> Register(ApplicationUser user, string password)
        {
            var result = await this.userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                throw new ApiException("CREATE_USER_ERROR", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
        {
            var result = await this.userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                throw new ApiException("UPDATE_USER_ERROR", HttpStatusCode.InternalServerError);
            }
        }
    }
}

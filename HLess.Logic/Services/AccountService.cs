using HLess.Logic.Services.Interfaces;
using HLess.Logic.Wrappers.Interfaces;
using HLess.Models.Entities;
using System.Threading.Tasks;

namespace HLess.Logic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserManagerWrapper userManager;

        public AccountService(IUserManagerWrapper userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> Register(ApplicationUser user, string password)
        {
            return await this.userManager.Register(user, password);
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            return await this.userManager.UpdateAsync(user);
        }
    }
}

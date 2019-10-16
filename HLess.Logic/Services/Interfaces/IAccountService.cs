using HLess.Models.Entities;
using System.Threading.Tasks;

namespace HLess.Logic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUser> Register(ApplicationUser user, string password);
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
    }
}

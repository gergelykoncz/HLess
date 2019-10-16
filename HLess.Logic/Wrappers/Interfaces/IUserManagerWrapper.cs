using HLess.Models.Entities;
using System.Threading.Tasks;

namespace HLess.Logic.Wrappers.Interfaces
{
    public interface IUserManagerWrapper
    {
        Task<ApplicationUser> Register(ApplicationUser user, string password);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user);
    }
}

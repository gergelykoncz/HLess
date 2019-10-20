using IdentityServer4.Services;
using System.Threading.Tasks;

namespace HLess.API.Identity
{
    /// <summary>
    /// Allow everyone to connect to identity server.
    /// </summary>
    public class BypassCorsPolicyService : ICorsPolicyService
    {
        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            return Task.FromResult(true);
        }
    }
}

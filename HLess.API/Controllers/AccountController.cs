using HLess.Logic.Facades.Interfaces;
using HLess.Models.Requests;
using HLess.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HLess.API.Controllers
{
    /// <summary>
    /// Controller for account-related actions.
    /// </summary>
    [ApiVersion("1")]
    [ApiController]
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IAccountFacade accountFacade;

        public AccountController(IAccountFacade accountFacade)
        {
            this.accountFacade = accountFacade;
        }

        /// <summary>
        /// Endpoint for registering a new account.
        /// </summary>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(CreateAccountSuccessDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(CreateAccountDto model)
        {
            var result = await this.accountFacade.Register(model);
            return Ok(result);
        }
    }
}
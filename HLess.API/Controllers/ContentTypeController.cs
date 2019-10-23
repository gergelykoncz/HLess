using HLess.Logic.Facades.Interfaces;
using HLess.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLess.API.Controllers
{
    /// <summary>
    /// Controller for working with content types.
    /// </summary>
    [ApiVersion("1")]
    [ApiController]
    [Route("contentType")]
    [Authorize]
    public class ContentTypeController : Controller
    {
        private readonly IContentTypeFacade facade;

        public ContentTypeController(IContentTypeFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContentTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            Guid userId = Guid.Parse(User.Claims.Single(x => x.Type == "sub").Value);
            var result = await this.facade.GetContentTypesForUser(userId, false);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContentTypeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(ContentTypeDto model)
        {
            Guid userId = Guid.Parse(User.Claims.Single(x => x.Type == "sub").Value);
            var result = await this.facade.CreateContentType(userId, model);
            return Ok(result);
        }
    }
}

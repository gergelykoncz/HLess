using HLess.Logic.Facades.Interfaces;
using HLess.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HLess.API.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("contentType")]
    public class ContentTypeController : Controller
    {
        private readonly IContentTypeFacade facade;

        public ContentTypeController(IContentTypeFacade facade)
        {
            this.facade = facade;
        }

        [Route("{userId}/{includeDeleted?}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContentTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid userId, bool includeDeleted = false)
        {
            var result = await this.facade.GetContentTypesForUser(userId, includeDeleted);
            return Ok(result);
        }
    }
}

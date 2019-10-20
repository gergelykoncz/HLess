using HLess.Logic.Facades.Interfaces;
using HLess.Models.Exceptions;
using HLess.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace HLess.API.Controllers
{
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

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<ContentTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int userId)
        {
               throw new ApiException("INVALID_STUFF", HttpStatusCode.BadRequest);
            var result = await this.facade.GetContentTypesForUser(new Guid(), false);
            return Ok(result);
        }
    }
}

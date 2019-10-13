using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HLess.API.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
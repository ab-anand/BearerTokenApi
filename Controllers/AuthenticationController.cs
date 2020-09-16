using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureAPI.Models;
using SecureAPI.Services;
using SecureAPI.Utils;

namespace SecureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]User model)
        {
            User user = null;
            if (model.Encrypted == null || model.Encrypted == false)
            {
                string secret = "This is a sample secret";
                user = _authenticateService.Authenticate(HmacConversion.CreateToken(model.ClientId, secret));
            }
            else
            {
                user = _authenticateService.Authenticate(model.ClientId);
            }

            if (user == null)
                return BadRequest(new { message = "ClientId Invalid."  });

            return Ok(user);
        }
    }
}

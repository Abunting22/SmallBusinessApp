using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthentication authentication) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult> CustomerLogin([FromForm] LoginDto request)
        {
            var result = await authentication.LoginRequest(request);
            return Ok(new { Token = result.JwtToken });
        }
    }
}

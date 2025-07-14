using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.Interfaces;
using SuperMarketWebApi.Core.Records;

namespace SuperMarketWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest request, CancellationToken ct)
        {
            var accessToken = await _authService.SignIn(request, ct);
            return Ok(accessToken);
        }
        
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request, CancellationToken ct)
        {
            await _authService.SignUp(request, ct);
            return NoContent();
        }
    }
}


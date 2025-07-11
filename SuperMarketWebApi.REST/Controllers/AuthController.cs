using Microsoft.AspNetCore.Mvc;

public record SignUpRequest(string Email, string FullName, string Password);

public record SignInRequest(string Email, string Password);

public record SignInResponse(string AccessToken);

namespace SuperMarketWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AuthController : Controller
    {
        
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest request, CancellationToken ct)
        { 
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request, CancellationToken ct)
        {
            return Ok();
        }
    
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperMarketWebApi.Interfaces;
using SuperMarketWebApi.Core.Entities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using SuperMarketWebApi.Core.Exceptions;
using SuperMarketWebApi.Core.Records;
using SuperMarketWebApi.Core.Settings;

namespace SuperMarketWebApi.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<SuperMarketUser> _userManager;
    private readonly SignInManager<SuperMarketUser> _signInManager;
    private readonly IConfiguration _config;

    public AuthService(UserManager<SuperMarketUser> userManager, SignInManager<SuperMarketUser> signInManager, IConfiguration config)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }
    
    public async Task<SignInResponse> SignIn(SignInRequest request, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            throw new AuthException("Can not log in: invalid email");
        }
            
        var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);
            
        if (result.Succeeded)
        {
            var keyValue = _config.GetSection("SecurityKeys")["SK"];
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue));
            var sign = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var expiringData = DateTime.UtcNow.AddMinutes(30);
        
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiringData,
                signingCredentials: sign
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token)!;
            
            return new SignInResponse(accessToken);
        }
        else
        {
            throw new AuthException("Can not log in: invalid password");
        }
    }
    
    public async Task<bool> SignUp(SignUpRequest request, CancellationToken ct)
    {
        var user = new SuperMarketUser()
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            UserName = request.Email
        };
        
        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return true;
        }
        else
        {
            throw new AuthException(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
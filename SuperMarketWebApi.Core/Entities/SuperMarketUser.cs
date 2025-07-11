using Microsoft.AspNetCore.Identity;

namespace SuperMarketWebApi.Core.Entities;

public class SuperMarketUser : IdentityUser
{
    public string Name { get; set; }
    public string? Surname { get; set; }
    
}
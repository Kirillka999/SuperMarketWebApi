using Microsoft.AspNetCore.Diagnostics;

namespace SuperMarketWebApi.Core.Exceptions;

public class AuthException : Exception
{
    public AuthException(string message) : base(message) { }
}
namespace SuperMarketWebApi.Core.Exceptions;

public class GetCartException : Exception
{
    public GetCartException(string message) : base(message) { }
}
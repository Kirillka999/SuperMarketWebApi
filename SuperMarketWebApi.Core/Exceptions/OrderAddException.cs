namespace SuperMarketWebApi.Core.Exceptions;

public class OrderAddException : Exception
{
    public OrderAddException(string message) : base(message) { }
}
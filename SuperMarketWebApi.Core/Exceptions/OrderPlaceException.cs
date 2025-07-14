namespace SuperMarketWebApi.Core.Exceptions;

public class OrderPlaceException : Exception
{
    public OrderPlaceException(string message) : base(message) { }
}
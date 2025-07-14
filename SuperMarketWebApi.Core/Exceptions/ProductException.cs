namespace SuperMarketWebApi.Core.Exceptions;

public class ProductException : Exception
{
    public ProductException(string message) : base(message) { }
}
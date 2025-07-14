namespace SuperMarketWebApi.Core.Records;

public record SignUpRequest(string Name, string Surname, string Email, string Password);
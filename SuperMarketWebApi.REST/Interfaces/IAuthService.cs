using SuperMarketWebApi.Core.Records;

namespace SuperMarketWebApi.Interfaces;

public interface IAuthService
{
    public Task<SignInResponse> SignIn(SignInRequest request, CancellationToken ct);
    public Task<bool> SignUp(SignUpRequest request, CancellationToken ct);
}
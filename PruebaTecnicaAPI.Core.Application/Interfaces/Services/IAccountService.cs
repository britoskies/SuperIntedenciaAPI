using PruebaTecnicaAPI.Core.Application.Dtos.Account;

namespace PruebaTecnicaAPI.Core.Application.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest req);
        Task SignOutAsync();
    }
}
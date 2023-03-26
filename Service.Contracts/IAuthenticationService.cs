using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForReg);

        Task<bool> ValidateUser(UserForAuthDto userForAuth);

        Task<string> CreateToken();
    }
}

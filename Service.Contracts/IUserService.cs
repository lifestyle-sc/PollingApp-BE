using Shared.DTOs;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(Guid id);
    }
}

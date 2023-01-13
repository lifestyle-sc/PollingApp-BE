using Shared.DTOs;

namespace Service.Contracts
{
    public interface IPollService
    {
        Task<PollDto> CreatePollForUser(Guid userId, PollForCreationDto pollForCreation);
    }
}

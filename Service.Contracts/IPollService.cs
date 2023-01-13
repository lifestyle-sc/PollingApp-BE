using Shared.DTOs;

namespace Service.Contracts
{
    public interface IPollService
    {
        Task<PollDto> CreatePollForUserAsync(Guid userId, PollForCreationDto pollForCreation);

        Task<IEnumerable<PollDto>> GetPollsForUserAsync(Guid userId, bool trackChanges);
    }
}

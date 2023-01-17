using Shared.DTOs;

namespace Service.Contracts
{
    public interface IPollService
    {
        Task<PollDto> CreatePollForUserAsync(Guid userId, PollForCreationDto pollForCreation);

        Task<IEnumerable<PollDto>> GetPollsForUserAsync(Guid userId, bool trackChanges);

        Task<PollDto> GetPollForUserAsync(Guid userId, Guid id, bool trackChanges);

        //Task<IEnumerable<PollDto>> GetPollsByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges);
    }
}

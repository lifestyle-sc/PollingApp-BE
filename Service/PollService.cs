using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DTOs;

namespace Service
{
    internal sealed class PollService : IPollService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager; 

        public PollService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PollDto> CreatePollForUser(Guid userId, PollForCreationDto pollForCreation)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if(user == null)
                throw new UserNotFoundException(userId);

            if (pollForCreation.Deadline <= DateTime.Now)
                throw new DeadlineParameterBadRequestException(pollForCreation.Deadline);

            var poll = _mapper.Map<Poll>(pollForCreation);

            _repository.Poll.CreatePollForUser(userId, poll);

            await _repository.SaveAsync();

            var pollToReturn = _mapper.Map<PollDto>(poll);

            return pollToReturn;
        }
    }
}

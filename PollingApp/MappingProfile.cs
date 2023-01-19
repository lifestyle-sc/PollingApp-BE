using AutoMapper;
using Entities.Models;
using Shared.DTOs;

namespace PollingApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();

            CreateMap<User, UserDto>();

            CreateMap<PollForCreationDto, Poll>();

            CreateMap<Poll, PollDto>();

            CreateMap<CandidateForCreationDto, Candidate>();

            CreateMap<Candidate, CandidateDto>();

            CreateMap<CandidateForUpdateDto, Candidate>();
        }
    }
}

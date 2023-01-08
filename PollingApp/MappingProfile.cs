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
        }
    }
}

﻿using AutoMapper;
using Entities.Models;
using Shared.DTOs;

namespace PollingApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();

            CreateMap<PollForCreationDto, Poll>();

            CreateMap<Poll, PollDto>();
        }
    }
}

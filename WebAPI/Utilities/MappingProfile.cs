using AutoMapper;
using Entities.AuthenticationModel;
using Entities.Dtos;

namespace WebAPI.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}

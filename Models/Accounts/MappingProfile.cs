using AutoMapper;

namespace Catblog.Models.Accounts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>();
        }
    }
}

using ApplicationCore.Commads;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, Usuario>().ForMember(x => x.Id, y => y.Ignore());
        }
    }
}

using ApplicationCore.Commads;
using ApplicationCore.DTOs;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(x => x.Id, y => y.Ignore());

            //<CreateUserCommand, Usuario>().ForMember(x => x.Id, y => y.Ignore());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ApplicationCore.DTOs.Usuario;
using AutoMapper;

namespace ApplicationCore.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<UsuarioDTO, Usuarios>()
            .ForMember(x => x.Id , y => y.Ignore());
        }

    }
}

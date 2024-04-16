using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ApplicationCore.DTOs.Usuario;
using AutoMapper;
using ApplicationCore.DTOs;

namespace ApplicationCore.Mappers
{
    public class AsignaturaProfile : Profile
    {
        public AsignaturaProfile() {
            CreateMap<AsignaturaDTO, AsignaturaCompleta>().ForMember(x => x.pkAsignatura, y =>y.Ignore());
        }
    }
}

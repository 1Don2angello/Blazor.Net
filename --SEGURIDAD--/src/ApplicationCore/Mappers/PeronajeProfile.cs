using ApplicationCore.DTOs.Personaje;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mappers
{
    public class PeronajeProfile:Profile
    {
        public PeronajeProfile() {
            CreateMap<PersonajeDto, Personajes>()
            .ForMember(x => x.PkPersonaje, y => y.Ignore());
        }
    }
}

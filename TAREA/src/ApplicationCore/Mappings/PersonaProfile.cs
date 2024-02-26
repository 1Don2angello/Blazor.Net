using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.DTOs.persona;
using ApplicationCore.DTOs;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappers
{
    public class PersonaProfile:Profile
    {
        public PersonaProfile() { 
        CreateMap<PersonaDto, Usuers>()
            .ForMember(x => x.Id, y => y.Ignore());
        }
        
    }
}

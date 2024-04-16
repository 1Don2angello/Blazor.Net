using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ApplicationCore.DTOs.Usuario;
using AutoMapper;
using ApplicationCore.DTOs;

namespace ApplicationCore.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProfesoresDTO, ProfesorCompleto>();
            // Incluye aquí otros mapeos que necesites

        }
    }

}

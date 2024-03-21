using ApplicationCore.DTOs.Logs;
using ApplicationCore.DTOs.Personaje;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mappers
{
    internal class LogProfile: Profile
    {
        public LogProfile(){
            CreateMap<LogsDto, Logs>()
            .ForMember(x => x.Ip, y => y.Ignore())
            .ForMember(x => x.Id, y => y.Ignore());

        }
    }
}

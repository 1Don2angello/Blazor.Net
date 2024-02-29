using ApplicationCore.Commads;
using ApplicationCore.DTOs;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class LogsProfile : Profile
    {
        public LogsProfile()
        {
            CreateMap<LogsDto, Logs>().ForMember(x => x.Id, y => y.Ignore());
        }
    }
}


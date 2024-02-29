using ApplicationCore.DTOs;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commads
{
        public class CreateLogsCommand : LogsDto, IRequest<Response<int>>
        {

        }
   
}

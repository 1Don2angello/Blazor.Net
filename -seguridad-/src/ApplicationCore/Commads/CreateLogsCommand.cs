using ApplicationCore.DTOs;
using ApplicationCore.Wrappers;


namespace ApplicationCore.Commads
{
    public class CreateLogsCommand : LogsDto, IRequest<Response<int>>
    {

    }

}
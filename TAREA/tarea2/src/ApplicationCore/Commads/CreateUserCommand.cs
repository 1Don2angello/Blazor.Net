using ApplicationCore.DTOs;
using ApplicationCore.Wrappers;
using MediatR;

namespace ApplicationCore.Commads
{
    public class CreateUserCommand : UsuarioDto, IRequest<Response<int>>
    {
    }
}

using ApplicationCore.DTOs;
using ApplicationCore.Wrappers;

namespace ApplicationCore.Commads
{
    public class CreateUserCommand : UsuarioDto, IRequest<Response<int>>
    {
    }
    public class UsuarioDto
    {
    }
}

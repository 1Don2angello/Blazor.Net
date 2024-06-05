using ApplicationCore.Wrappers;

using AutoMapper;
using Infraestructure.Persistence;
using ApplicationCore.Commads;

namespace Infraestructure.EventHandlers.Users
{
    public class CreateUsersHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateUsersHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        //{
        //    var c = new CreateUserCommand();
        //    c.Nombre = request.Nombre;
        //    c.Apellido = request.Apellido;
            
          //  var ca = _mapper.Map<Domain.Entities.Usuarios>(c);
          //  await _context.Usuarios.AddAsync(ca);
          //  await _context.SaveChangesAsync();
         //   
         //   return new Response<int>(ca.Id, "Registro creado");
        //}
    }

    public interface IRequestHandler<T1, T2>
    {
    }
}
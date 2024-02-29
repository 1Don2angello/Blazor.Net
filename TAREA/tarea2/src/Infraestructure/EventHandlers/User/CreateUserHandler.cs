using ApplicationCore.Wrappers;
using MediatR;
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

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var c = new CreateUserCommand();
            c.Nombre = request.Nombre;
            c.Apellido_com = request.Apellido_com;
            c.Edad = request.Edad;
            c.Estatus = request.Estatus;
            c.Ciudad = request.Ciudad;

            
            var ca = _mapper.Map<Domain.Entities.Usuario>(c);
            await _context.user.AddAsync(ca);
            await _context.SaveChangesAsync();
            
            return new Response<int>(ca.Id, "Registro creado");
        }
    }
}
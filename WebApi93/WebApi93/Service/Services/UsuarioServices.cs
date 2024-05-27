using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi93.Context;
using WebApi93.Service.IServices;

namespace WebApi93.Service.Services
{
    public class Usuarioservices: IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        // Creacion de un constructor 

        public Usuarioservices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                List<Usuario> response = _context.Usuarios.ToListAsync();
                return new Response<List<Usuario>>(response);
            }
            catch
            {
                throw;
            }
        }
        //Crear usuario 
    }
}

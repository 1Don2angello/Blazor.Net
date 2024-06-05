using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi83.Context;
using WebApi83.Services.IServices;

namespace WebApi83.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        // Creación de un constructor

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios ()
        {
            try
            {

                List<Usuario> response = await _context.Usuarios.Include(y => y.Roles).ToListAsync();
                 
                return new Response<List<Usuario>>(response);

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error "+ex.Message);
            }
        }

        //Obtener Usuario
        public async Task<Response<Usuario>> ById(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);

                return new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }
            



        //Crear usuario

        public async Task<Response<Usuario>> Crear(UsuarioResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre= request.Nombre,
                    User= request.User,
                    Password= request.Password,
                    FKRol = request.FKRol
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }



    }
}

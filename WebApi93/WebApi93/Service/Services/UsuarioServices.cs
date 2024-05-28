using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
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
                List<Usuario> response = await _context.Usuarios.ToListAsync();
                return new Response<List<Usuario>>(response);
            }
            catch
            {
                throw;
            }
        }
        //Crear usuario 

        public async Task<Response<Usuario>> Crear (UsuarioResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol
                };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(usuario);
                
            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrió un error al crear el usuario: " + ex.Message, ex);

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
                throw new Exception("Ocurrio un error" + ex.Message);

            }
        }
        //editar usuario
        public async Task<Response<Usuario>> Editar(int id, UsuarioResponse request)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<Usuario>("Usuario no encontrado.");
                }

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password; // Considera usar hashing aquí
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el usuario: " + ex.Message, ex);
            }
        }
        //eliminar usuario
        public async Task<Response<bool>> Eliminar(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<bool>("Usuario no encontrado.");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return new Response<bool>(true, "Usuario eliminado con éxito.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el usuario: " + ex.Message, ex);
            }
        }



    }
}

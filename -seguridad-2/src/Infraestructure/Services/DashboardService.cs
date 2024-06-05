using ApplicationCore.DTOs;
using ApplicationCore.Parameters;
using ApplicationCore.DTOs.Usuario;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Infraestructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DashboardService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        /// validaciones 
        private void ValidateUsuarioCompletoDTO(UsuarioCompletoDTO usuario)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                errors.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                errors.Add("El apellido es obligatorio.");
            if (usuario.Edad <= 0)
                errors.Add("La edad debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@"))
                errors.Add("Debe proporcionar un correo electrónico válido.");
            if (string.IsNullOrWhiteSpace(usuario.Telefono))
                errors.Add("El teléfono es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Direccion))
                errors.Add("La dirección es obligatoria.");
            if (string.IsNullOrWhiteSpace(usuario.Ciudad))
                errors.Add("La ciudad es obligatoria.");
            if (string.IsNullOrWhiteSpace(usuario.Pais))
                errors.Add("El país es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.CodigoPostal))
                errors.Add("El código postal es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Genero))
                errors.Add("El género es obligatorio.");
            // Agregar más validaciones conforme a las reglas de negocio
            if (errors.Any())
                throw new ArgumentException(string.Join(" ", errors));
        }


        /// <summary>
        /// get data

        public async Task<object> GetData(int pageNumber, int pageSize)
        {
            var query = _dbContext.Usuarios.AsQueryable();

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Ensure the page number is not out of range
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageNumber = pageNumber > totalPages ? totalPages : pageNumber;

            var skip = (pageNumber - 1) * pageSize;
            var data = await query.Skip(skip).Take(pageSize).ToListAsync();

            var pagedResponse = new
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Users = data
            };

            return pagedResponse;
        }




        /// este es create con try cachar
        public async Task<Response<int>> Create(UsuarioCompletoDTO request)
        {
            try
            {
                // Validar el DTO de entrada
                ValidateUsuarioCompletoDTO(request);
                var usuario = _mapper.Map<UsuarioCompleto>(request);
                await _dbContext.Usuarios.AddAsync(usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(usuario.Id, "Usuario creado exitosamente.");
            }
            catch (Exception ex)
            {
                // Aquí registras el error antes de lanzar la excepción para que sea capturado en un nivel superior,
                // como un middleware de manejo de errores que puede registrar el error y responder adecuadamente.
                await LogError("Create", JsonConvert.SerializeObject(request), ex.Message);
                return new Response<int>(0, ex.Message);
            }
        }

        ///// este es update 
        public async Task<Response<int>> Update(UsuarioCompletoDTO request)
        {
            try
            {
                ValidateUsuarioCompletoDTO(request);
                var usuario = await _dbContext.Usuarios.FindAsync(request.Id);
                if (usuario == null)
                {
                    throw new KeyNotFoundException($"Usuario con ID {request.Id} no encontrado.");
                }
                _mapper.Map(request, usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(usuario.Id, "Usuario actualizado exitosamente");
            }
            catch (Exception ex)
            {
                await LogError("Update", JsonConvert.SerializeObject(request), ex.Message);
                return new Response<int>(0, ex.Message);
            }
        }
        /// este es delete 

        public async Task<Response<int>> Delete(int id)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    throw new KeyNotFoundException($"Usuario con ID {id} no encontrado.");
                }
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(id, "Usuario eliminado exitosamente");
            }
            catch (Exception ex)
            {
                await LogError("Delete", id.ToString(), ex.Message);
                return new Response<int>(0, ex.Message); 
            }
        }


        ///este es de los logs
        
        public async Task<Response<int>> GetLogsCreate(LogsDto request)
        {
            try
            {
                // Suponiendo que tienes una entidad 'Log' y un DbContext 'dbContext' para acceder a tu base de datos
                var logEntry = new Logs
                {
                    IpAdress = request.IpAdress,
                    Respuesta = request.Respuesta,
                    Datos = request.Datos,
                    Funcion = request.Funcion,
                    // Puedes agregar más campos aquí si es necesario, como una marca de tiempo, etc.
                };

                _dbContext.logs.Add(logEntry);
                await _dbContext.SaveChangesAsync();

                return new Response<int>(logEntry.Id,"Log creado exitosamente.");
            }
            catch (Exception ex)
            {
                // Aquí deberías manejar el error de alguna manera.
                // Por ejemplo, puedes querer registrar en una salida de consola o en un archivo.
                Console.WriteLine($"Error al crear log: {ex.Message}");

                // Devuelve un código de respuesta apropiado para la excepción
                return new Response<int>(0, "Error al registrar el log.");
            }
        }

        ////
        ///este funciona y usa log error
        private async Task LogError(string funcion, string datos, string respuesta, string ipAdress = null)
        {
            var log = new Logs
            {
                IpAdress = ipAdress ?? GetClientIp(),
                Funcion = funcion,
                Datos = datos,
                Respuesta = respuesta
            };

            _dbContext.logs.Add(log);
            await _dbContext.SaveChangesAsync();
        }

        private string GetClientIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            return ip?.ToString() ?? "IP desconocida";
        }



        public async Task<Response<string>> GetIp()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
                if (ip == null)
                {
                    throw new Exception("Dirección IP no encontrada en la red de interconexión.");
                }
                return new Response<string>(ip.ToString(), "IP encontrada con éxito.");
            }
            catch (Exception ex)
            {
                // Aquí deberías registrar el error, dependiendo de tu infraestructura de logging.
                // Por ejemplo, si tienes un método LogError como se ha mostrado en ejemplos anteriores:
                await LogError("GetIp", "", ex.Message);
                return new Response<string>(null, ex.Message);
            }
        }


        /// este es create con try cachar
        //public async Task<Response<int>> CreateProfesor(ProfesoresDTO request)
        //{
        //    try
        //    {
        //        // Validar el DTO de entrada
        //        ValidateProfesorDTO(request);
        //        var profesor = _mapper.Map<ProfesoresDTO>(request);
        //        await _dbContext.Profesores.AddAsync(profesor);
        //        await _dbContext.SaveChangesAsync();
        //        return new Response<int>(profesor.pkProfesor, "Profesor creado exitosamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Aquí registras el error antes de lanzar la excepción para que sea capturado en un nivel superior,
        //        // como un middleware de manejo de errores que puede registrar el error y responder adecuadamente.
        //        await LogError("Create", JsonConvert.SerializeObject(request), ex.Message);
        //        return new Response<int>(0, ex.Message);
        //    }
        //}

        public async Task<Response<int>> CreateProfesor(ProfesoresDTO request)
        {
            
            // Asegúrate de que el mapeo se hace hacia la entidad correcta (ProfesorCompleto)
            var profesor = _mapper.Map<ProfesorCompleto>(request);

            // Añadir el profesor mapeado al contexto
            await _dbContext.Profesores.AddAsync(profesor);
            // Guardar los cambios en la base de datos
            await _dbContext.SaveChangesAsync();
            // Devolver un Response<int> con el ID del profesor, que es lo que espera la interfaz
            return new Response<int>(profesor.pkProfesor, "Profesor creado exitosamente.");
        }


        /// validaciones 
        private void ValidateProfesorDTO(ProfesorCompleto profesor)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(profesor.Nombre))
                errors.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(profesor.ApMaterno))
                errors.Add("El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(profesor.ApPaterno))
                errors.Add("El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(profesor.Matricula))
                errors.Add("Debe proporcionar una matricula válido.");
           //-- if (DateTime.IsNullOrWhiteSpace(profesor.FechaIngreso))
             //---   errors.Add("El teléfono es obligatorio.");
           
            
            // Agregar más validaciones conforme a las reglas de negocio
            if (errors.Any())
                throw new ArgumentException(string.Join(" ", errors));
        }



    }
}

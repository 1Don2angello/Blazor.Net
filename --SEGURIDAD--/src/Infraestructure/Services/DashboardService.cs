using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Dapper;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.DTOs.Personaje;
using System.Net.Sockets;
using System.Net;
using ApplicationCore.DTOs.Logs;
using System.Text.Json;
using System.Xml.Linq;

namespace Infraestructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public DashboardService(ApplicationDbContext dbContext, ICurrentUserService currentUserService, IMapper mapper)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<Response<object>> GetData()
        {
            object list = new object(); 
            list = await _dbContext.personajes.ToListAsync();

            return new Response<object>(list);
        }

        public async Task<Response<int>> Create(PersonajeDto request)
        {
            var newPersonaje = _mapper.Map<Domain.Entities.Personajes>(request);
            var personajeEntitie = await _dbContext.personajes.AddAsync(newPersonaje);
            string dataJson = JsonSerializer.Serialize(newPersonaje);

            try
            {
                await _dbContext.SaveChangesAsync();

                var respuesta = new Response<int>(1, "Registro Creado");

                var name = "Name: " + request.Nombre.ToString();
                var level = "Nivel: " + request.Nivel.ToString();
                var getIt = "Conseguido: " + request.Conseguido.ToString();
                var wepon = "Arma: " + request.Arma.ToString();

                //var dataJson = JsonSerializer.Serialize(newPersonaje);
                var log = new LogsDto();
                log.Datos = name + "," + level + "," + getIt + "," + wepon;
                log.Nombre_funcion = "CreatePersonaje";
                log.Respuesta = respuesta.Message;

                await CreateLogs(log);
                return respuesta;

            }catch (Exception ex) {
                personajeEntitie.State = EntityState.Detached;
                var log = new LogsDto();
                log.Datos = "sin datos";
                log.Nombre_funcion = "CreatePersonaje";
                log.Respuesta = ex.Message;

                await CreateLogs(log);
                return new Response<int>(0);
            }
        }

        public async Task<Response<int>> Update(PersonajeDto request, int personajeId)
        {
            var newPersonaje = _mapper.Map<Domain.Entities.Personajes>(request);

            try
            {
                var personajeExistente = await _dbContext.personajes.FindAsync(personajeId);
                if (personajeExistente == null)
                {
                    throw new Exception("Personaje no encontrado");
                }

                _mapper.Map(request, personajeExistente);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(1, "Personaje actualizado exitosamente.");

            }
            catch (Exception ex) 
            {
                var log = new LogsDto();
                log.Datos = $"Error al actualizar el personaje con ID {personajeId}.";
                log.Nombre_funcion = "UpdatePersonaje";
                log.Respuesta = ex.Message;

                await CreateLogs(log);
                return new Response<int>(0, $"Error al actualizar el personaje: {ex.Message}");
            }

        }

        public async Task<Response<int>> Delete(int personajeId)
        {
            try
            {
                var personajeExistente = await _dbContext.personajes.FindAsync(personajeId);
                if (personajeExistente == null)
                {
                    throw new Exception("Personaje no encontrado");
                }

                _dbContext.personajes.Remove(personajeExistente);
                await _dbContext.SaveChangesAsync();
                return new Response<int>(1, "Personaje eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                var log = new LogsDto();
                log.Datos = $"Error al eliminar el personaje con ID {personajeId}.";
                log.Nombre_funcion = "Delete";
                log.Respuesta = ex.Message;

                await CreateLogs(log);
                return new Response<int>(0, $"Error al eliminar el personaje: {ex.Message}");
            }
        }

        public async Task<Response<string>> GetIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            var Ip = iPAddress?.ToString() ?? "No se pudo determinar la dirección Ip";
            return new Response<string>(Ip);
        }

        public async Task<Response<int>> CreateLogs(LogsDto request)
        {
            try {
            
            var Ip = await GetIp();
            var newLog = _mapper.Map<Domain.Entities.Logs>(request);
            newLog.Ip = Ip.Message;
            await _dbContext.logs.AddAsync(newLog);
            await _dbContext.SaveChangesAsync();
            return new Response<int>(1);
            } 
            catch (Exception error){
                return new Response<int>(0);
                var er = error;
            }

        }
    }
}

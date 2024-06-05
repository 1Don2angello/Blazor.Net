using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi83.Context;
using WebApi83.Services.IServices;

namespace WebApi83.Services.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDbContext _context;

        public AutorServices(ApplicationDbContext context)
        {
            _context= context;
        }


        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType:CommandType.StoredProcedure);

                response = result.ToList();

                return new Response<List<Autor>> ( response );
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error :C "+ex.Message);
            }
        }


        public async Task<Response<Autor>> Crear(Autor i)
        {
            try
            {
                //Autor autor = new Autor();

                Autor autor = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();


               
                
                return new Response<Autor>(autor);


            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error :C " + ex.Message);
            }

        }





    }
}

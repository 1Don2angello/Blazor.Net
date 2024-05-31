using WebApi93.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using WebApi93.Service.IServices;
namespace WebApi93.Service.Services
{
    public class AutorServices :IAutorServices
    {
        private readonly ApplicationDbContext _context;

        public AutorServices (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores ()
        {
            try
            {
                List<Autor> response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);
                response = result.ToList();

                return new Response<List<Autor>> ( response );
            }catch (Exception ex)
            {
                return new Response<List<Autor>>();
            }
        }
    }
}

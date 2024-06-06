using Microsoft.AspNetCore.Mvc;
using WebApi93.Service.Services;
using WebApi93.Service.IServices;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
namespace WebApi93.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;

        public AutoresController (IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok( await _autorServices.GetAutores() );
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody]Autor autor )
        {
            return  Ok(await _autorServices.Crear(autor ));
        }

    }

}

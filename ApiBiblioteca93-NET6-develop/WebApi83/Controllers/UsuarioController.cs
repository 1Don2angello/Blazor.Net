using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi83.Services.IServices;

namespace WebApi83.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
       
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices= usuarioServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var reponse = await _usuarioServices.ObtenerUsuarios();

            return Ok(reponse);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _usuarioServices.ById(id));

        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UsuarioResponse request)
        {
            return Ok(await _usuarioServices.Crear(request));

        }


        //Tarea: Terminar el CRUD Completo de usuarios 

    }
}

using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi93.Service.IServices;

namespace WebApi93.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;


        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usuarioServices.ObtenerUsuarios();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UsuarioResponse request)
        {
            return Ok(await _usuarioServices.Crear(request));
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _usuarioServices.ById (id));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UsuarioResponse request)
        {
            var response = await _usuarioServices.Editar(id, request);
            if (!response.Succeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _usuarioServices.Eliminar(id);
            if (!response.Succeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}

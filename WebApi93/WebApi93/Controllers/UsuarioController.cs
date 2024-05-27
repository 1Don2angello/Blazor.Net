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


        public UsuarioController (IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usuarioServices.ObtenerUsuarios();
            return Ok(response);
        }
    }
}

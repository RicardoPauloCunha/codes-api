using Microsoft.AspNetCore.Mvc;
using DatabaseFirst.Senatur.Interface;
using DatabaseFirst.Senatur.Repositoio;

namespace DatabaseFirst.Senatur.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public UsuariosController()
        {
            _usuariosRepositorio = new UsuariosRepositorio();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuariosRepositorio.Listar());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
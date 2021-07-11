using System;
using Microsoft.AspNetCore.Mvc;
using DatabaseFirst.InLock.Interfaces;
using DatabaseFirst.InLock.Repositorios;

namespace DatabaseFirst.InLock.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepositorio UsuariosRepositorio{ get; set; }

        public UsuariosController()
        {
            UsuariosRepositorio = new UsuariosRepositorio();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(UsuariosRepositorio.Listar());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.DatabaseFisrt.Solution.Interfaces;
using Senai.InLock.DatabaseFisrt.Solution.Repositorios;

namespace Senai.InLock.DatabaseFisrt.Solution.Controllers
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
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
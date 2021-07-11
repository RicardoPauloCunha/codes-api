using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Standard.InLock.Interfaces;
using Standard.InLock.Repositorios;

namespace Standard.InLock.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private readonly IEstudiosRepositorio _estudiosRepositorio;

        public EstudiosController()
        {
            _estudiosRepositorio = new EstudiosRepositorio();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_estudiosRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("jogos")]
        public IActionResult ListarEstudiosJogos()
        {
            try
            {
                return Ok(_estudiosRepositorio.ListarEstudioJogo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
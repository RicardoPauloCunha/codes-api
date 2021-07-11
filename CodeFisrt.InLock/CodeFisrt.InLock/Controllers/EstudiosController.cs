using System;
using Microsoft.AspNetCore.Mvc;
using CodeFisrt.InLock.Contexts;
using CodeFisrt.InLock.Domains;
using CodeFisrt.InLock.Interfaces;
using CodeFisrt.InLock.Repositorios;

namespace CodeFisrt.InLock.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepositorio EstudiosRepositorio { get; set; }

        public EstudiosController()
        {
            EstudiosRepositorio = new EstudiosRepositorio();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(EstudiosRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(EstudiosDomain estudio)
        {
            try
            {
                EstudiosRepositorio.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put(EstudiosDomain estudio)
        {
            try
            {
                InLockContext ctx = new InLockContext();
                EstudiosDomain estudioExiste = ctx.Estudios.Find(estudio.Id);

                if(estudioExiste == null)
                {
                    return NotFound("Estudio não encotrado");
                }

                EstudiosRepositorio.Alterar(estudio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{estudioId}")]
        public IActionResult Delete(int estudioId)
        {
            try
            {
                InLockContext ctx = new InLockContext();
                EstudiosDomain estudioExiste = ctx.Estudios.Find(estudioId);

                if (estudioExiste == null)
                {
                    return NotFound("Estudio não encotrado");
                }

                EstudiosRepositorio.Deletar(estudioExiste);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.CodeFisrt.WebApi.Manha.Contexts;
using Senai.InLock.CodeFisrt.WebApi.Manha.Domains;
using Senai.InLock.CodeFisrt.WebApi.Manha.Interfaces;
using Senai.InLock.CodeFisrt.WebApi.Manha.Repositorios;

namespace Senai.InLock.CodeFisrt.WebApi.Manha.Controllers
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
                EstudiosDomain estudioExiste = ctx.Estudios.Find(estudio.EstudioId);

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
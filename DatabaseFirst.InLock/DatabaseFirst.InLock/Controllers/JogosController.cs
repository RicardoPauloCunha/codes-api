using System;
using Microsoft.AspNetCore.Mvc;
using DatabaseFirst.InLock.Domains;
using DatabaseFirst.InLock.Interfaces;
using DatabaseFirst.InLock.Repositorios;

namespace DatabaseFirst.InLock.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepositorio JogosRepositorio{ get; set; }

        public JogosController()
        {
            JogosRepositorio = new JogosRepositorio();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(JogosRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/JogosComEstudios")]
        public IActionResult Get2()
        {
            try
            {
                return Ok(JogosRepositorio.ListarJogosEstudios());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Jogos jogo)
        {
            try
            {
                JogosRepositorio.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put(Jogos jogo)
        {
            try
            {
                InLockContext ctx = new InLockContext();
                Jogos jogoExiste = ctx.Jogos.Find(jogo.Id);

                if (jogoExiste == null)
                {
                    return NotFound("Jogo não Existe");
                }

                JogosRepositorio.Alterar(jogo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{jogoId}")]
        public IActionResult Delte(int jogoId)
        {
            try
            {
                InLockContext ctx = new InLockContext();
                Jogos jogoExiste = ctx.Jogos.Find(jogoId);

                if (jogoExiste == null)
                {
                    return NotFound("Jogo não Existe");
                }

                JogosRepositorio.Remover(jogoExiste);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
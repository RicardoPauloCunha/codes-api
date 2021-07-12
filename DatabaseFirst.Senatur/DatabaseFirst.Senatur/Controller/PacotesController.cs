using System;
using Microsoft.AspNetCore.Mvc;
using DatabaseFirst.Senatur.Domains;
using DatabaseFirst.Senatur.Interface;
using DatabaseFirst.Senatur.Repositoio;

namespace DatabaseFirst.Senatur.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private readonly IPacotesRepositorio _pacotesRepositorio;

        public PacotesController()
        {
            _pacotesRepositorio = new PacotesRepositorio();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacotesRepositorio.Listar());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(Pacotes pacote)
        {
            try
            {
                _pacotesRepositorio.Cadastrar(pacote);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(Pacotes pacote)
        {
            try
            {
                _pacotesRepositorio.Alterar(pacote);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
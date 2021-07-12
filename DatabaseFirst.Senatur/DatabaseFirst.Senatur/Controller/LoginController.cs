using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using DatabaseFirst.Senatur.Domains;
using DatabaseFirst.Senatur.Interface;
using DatabaseFirst.Senatur.Repositoio;
using DatabaseFirst.Senatur.ViewModels;

namespace DatabaseFirst.Senatur.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public LoginController()
        {
            _usuariosRepositorio = new UsuariosRepositorio();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel userLogin)
        {
            try
            {
                Usuarios usuarioBuscado = _usuariosRepositorio.BuscarUsuario(userLogin);

                if(usuarioBuscado == null)
                    return BadRequest(new { mensagem = "Usuário não encontrado. Email ou Senha inválidos" });

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senatur-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "DatabaseFirst.Senatur",
                    audience: "DatabaseFirst.Senatur", 
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Standard.InLock.Domains;
using Standard.InLock.Interfaces;
using Standard.InLock.Repositorios;
using Standard.InLock.ViewModels;

namespace Standard.InLock.Controllers
{
    [Produces("application/json")]
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
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                UsuariosDomain UsuarioBuscado = _usuariosRepositorio.BuscarUsuario(login.Email, login.Senha);

                if(UsuarioBuscado == null)
                {
                    return NotFound(new { mesagem = "Email ou Senha Inválida" });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InLockGames",
                    audience: "InLockGames", 
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
using DatabaseFirst.Senatur.Domains;
using DatabaseFirst.Senatur.Interface;
using DatabaseFirst.Senatur.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseFirst.Senatur.Repositoio
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        public Usuarios BuscarUsuario(LoginViewModel userLogin)
        {
            Usuarios usuarioBuscado = new Usuarios();

            using (DatabaseFirst.SenaturContext ctx = new DatabaseFirst.SenaturContext())
            {
                usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == userLogin.Email && x.Senha == userLogin.Senha);
            }

            return usuarioBuscado;
        }

        public List<Usuarios> Listar()
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            using (DatabaseFirst.SenaturContext ctx = new DatabaseFirst.SenaturContext())
            {
                usuarios = ctx.Usuarios.ToList();
            }

            return usuarios;
        }
    }
}

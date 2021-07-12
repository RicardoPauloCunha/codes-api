using DatabaseFirst.Senatur.Domains;
using DatabaseFirst.Senatur.ViewModels;
using System.Collections.Generic;

namespace DatabaseFirst.Senatur.Interface
{
    interface IUsuariosRepositorio
    {
        List<Usuarios> Listar();
        Usuarios BuscarUsuario(LoginViewModel userLogin);
    }
}

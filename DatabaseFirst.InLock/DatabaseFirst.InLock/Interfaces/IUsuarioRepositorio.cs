using DatabaseFirst.InLock.Domains;
using System.Collections.Generic;

namespace DatabaseFirst.InLock.Interfaces
{
    interface IUsuarioRepositorio
    {
        List<Usuarios> Listar();
    }
}

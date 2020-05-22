using Senai.InLock.DatabaseFisrt.Solution.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DatabaseFisrt.Solution.Interfaces
{
    interface IUsuarioRepositorio
    {
        List<Usuarios> Listar();
    }
}

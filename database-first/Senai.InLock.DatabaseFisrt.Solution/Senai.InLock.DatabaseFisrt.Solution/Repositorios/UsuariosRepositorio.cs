using Senai.InLock.DatabaseFisrt.Solution.Domains;
using Senai.InLock.DatabaseFisrt.Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DatabaseFisrt.Solution.Repositorios
{
    public class UsuariosRepositorio : IUsuarioRepositorio
    {
        public List<Usuarios> Listar()
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            using (InLockContext ctx = new InLockContext())
            {
                usuarios = ctx.Usuarios.ToList();
            }

            return usuarios;
        }
    }
}

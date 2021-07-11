using DatabaseFirst.InLock.Domains;
using DatabaseFirst.InLock.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseFirst.InLock.Repositorios
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

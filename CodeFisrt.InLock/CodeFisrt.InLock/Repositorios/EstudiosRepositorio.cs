using CodeFisrt.InLock.Contexts;
using CodeFisrt.InLock.Domains;
using CodeFisrt.InLock.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CodeFisrt.InLock.Repositorios
{
    public class EstudiosRepositorio : IEstudiosRepositorio
    {
        public void Alterar(EstudiosDomain estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Update(estudio);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(EstudiosDomain estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public void Deletar(EstudiosDomain estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }

        public List<EstudiosDomain> Listar()
        {
            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (InLockContext ctx = new InLockContext())
            {
                estudios = ctx.Estudios.ToList();
            }

            return estudios;
        }
    }
}

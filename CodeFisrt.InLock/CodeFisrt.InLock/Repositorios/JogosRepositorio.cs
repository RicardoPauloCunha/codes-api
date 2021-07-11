using CodeFisrt.InLock.Contexts;
using CodeFisrt.InLock.Domains;
using CodeFisrt.InLock.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CodeFisrt.InLock.Repositorios
{
    public class JogosRepositorio : IJogosRepositorio
    {
        public void Alterar(JogosDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(JogosDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> jogos = new List<JogosDomain>();

            using (InLockContext ctx = new InLockContext())
            {
                jogos = ctx.Jogos.ToList();
            }

            return jogos;
        }

        public void Remover(JogosDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }
    }
}

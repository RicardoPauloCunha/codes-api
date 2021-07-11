using Microsoft.EntityFrameworkCore;
using DatabaseFirst.InLock.Domains;
using DatabaseFirst.InLock.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseFirst.InLock.Repositorios
{
    public class JogosRepositorio : IJogosRepositorio
    {
        public void Alterar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public List<Jogos> Listar()
        {
            List<Jogos> jogos = new List<Jogos>();

            using (InLockContext ctx = new InLockContext())
            {
                jogos = ctx.Jogos.ToList();
            }

            return jogos;
        }

        public List<Jogos> ListarJogosEstudios()
        {
            List<Jogos> jogos = new List<Jogos>();

            using (InLockContext ctx = new InLockContext())
            {
                jogos = ctx.Jogos.Include(x => x.Estudio).ToList();
            }

            return jogos;
        }

        public void Remover(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }
    }
}

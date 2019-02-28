using Microsoft.EntityFrameworkCore;
using Senai.InLock.DatabaseFisrt.Solution.Domains;
using Senai.InLock.DatabaseFisrt.Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DatabaseFisrt.Solution.Repositorios
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

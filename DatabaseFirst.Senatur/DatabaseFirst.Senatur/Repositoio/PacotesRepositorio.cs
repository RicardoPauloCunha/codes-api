using DatabaseFirst.Senatur.Domains;
using DatabaseFirst.Senatur.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseFirst.Senatur.Repositoio
{
    public class PacotesRepositorio : IPacotesRepositorio
    {
        public void Alterar(Pacotes pacote)
        {
            using (DatabaseFirst.SenaturContext ctx = new DatabaseFirst.SenaturContext())
            {
                ctx.Pacotes.Update(pacote);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Pacotes pacote)
        {
            using (DatabaseFirst.SenaturContext ctx = new DatabaseFirst.SenaturContext())
            {
                ctx.Pacotes.Add(pacote);
                ctx.SaveChanges();
            }
        }

        public List<Pacotes> Listar()
        {
            List<Pacotes> pacotes = new List<Pacotes>();

            using (DatabaseFirst.SenaturContext ctx = new DatabaseFirst.SenaturContext())
            {
                pacotes = ctx.Pacotes.ToList();
            }

            return pacotes;
        }
    }
}

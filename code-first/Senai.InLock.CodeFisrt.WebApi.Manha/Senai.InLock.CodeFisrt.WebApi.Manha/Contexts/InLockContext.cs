using Microsoft.EntityFrameworkCore;
using Senai.InLock.CodeFisrt.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFisrt.WebApi.Manha.Contexts
{
    public class InLockContext : DbContext
    {
        // Jogos
        public DbSet<JogosDomain> Jogos { get; set; }
        // Estudios
        public DbSet<EstudiosDomain> Estudios { get; set; }

        // Defina a string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=.\\SqlExpress; Initial Catalog=InLock-CodeFirst_Manha; User id=sa;pwd=132");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using CodeFisrt.InLock.Domains;

namespace CodeFisrt.InLock.Contexts
{
    public class InLockContext : DbContext
    {
        public DbSet<JogosDomain> Jogos { get; set; }
        public DbSet<EstudiosDomain> Estudios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connection-string");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

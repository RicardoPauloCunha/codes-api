using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Senatur.Domains
{
    public partial class DatabaseFirst.SenaturContext : DbContext
    {
        public DatabaseFirst.SenaturContext()
        {

        }

        public DatabaseFirst.SenaturContext(DbContextOptions<DatabaseFirst.SenaturContext> options): base(options)
        {

        }

        public virtual DbSet<Pacotes> Pacotes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("connection-string");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Pacotes");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Pacotes__77BB3B44D8186DBD")
                    .IsUnique();

                entity.Property(e => e.DataId).HasColumnType("date");

                entity.Property(e => e.DataVolta).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Usuarios");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105344C7E9698")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}

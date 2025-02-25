using ConviteCasamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConviteCasamento.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Acompanhante> Acompanhantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Convidado>()
                .HasMany(c => c.Acompanhantes)
                .WithOne(x => x.Convidado)
                .HasForeignKey(x => x.IdConvidado);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext() { }
    }
}

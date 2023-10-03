using Microsoft.EntityFrameworkCore;

namespace Modelli
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Utente> ListaUtenti { get; set; } = null!;

        public DbSet<Prodotto> ListaProdotti { get; set; } = null!;

        public DbSet<Acquisto> ListaAcquisti { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utente>().HasKey(u => new { u.Id });
            modelBuilder.Entity<Utente>().HasMany(u => u.ListaAcquisti).WithOne(a => a.Utente).HasForeignKey(x => x.IdUtente);

            modelBuilder.Entity<Prodotto>().HasKey(p => new { p.Id });
            modelBuilder.Entity<Prodotto>().HasMany(p => p.ListaAcquisti).WithOne(p => p.Prodotto).HasForeignKey(x => x.IdProdotto);

            modelBuilder.Entity<Acquisto>().HasKey(a => new { a.Id });

            base.OnModelCreating(modelBuilder);
        }
    }
}
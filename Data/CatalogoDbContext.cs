using Microsoft.EntityFrameworkCore;
using SSG_API.Models;

namespace SSG_API.Data
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(
            DbContextOptions<CatalogoDbContext> options) : base(options)
        { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.CodigoBarras);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class UnidadeDeCobrancaDbContext : DbContext
    {
        public DbSet<UnidadeDeCobrancaDbContext> UnidadeDeCobrancas { get; set; }

        public void Configure(EntityTypeBuilder<UnidadeDeCobrancaDbContext> builder)
        {
            builder.ToTable("UnidadedeCobranca");
            //builder.HasMany(p => p.ServicoPrestado);
        }
    }
}

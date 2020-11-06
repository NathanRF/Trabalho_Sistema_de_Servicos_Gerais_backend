using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class LocaisDeAtendimentoDbContext : DbContext
    {
        public DbSet<LocaisDeAtendimentoDbContext> locaisDeAtendimentos { get; set; }

        public void Configure(EntityTypeBuilder<LocaisDeAtendimentoDbContext> builder)
        {
            builder.ToTable("LocaisDeAtendimento");
            builder.HasKey(p => p.locaisDeAtendimentos);
            //builder.HasOne(p => p.PrestadorDeServico);
        }
    }
}

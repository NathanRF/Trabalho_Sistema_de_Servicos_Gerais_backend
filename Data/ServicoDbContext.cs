using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class ServicoDbContext : DbContext
    {
        public DbSet<Servico> Servicos { get; set; }

        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servico");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome);
            builder.Property(p => p.DescricaoServico);            
        }
    }
}

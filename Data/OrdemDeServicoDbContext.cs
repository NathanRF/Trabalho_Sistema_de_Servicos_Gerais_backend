using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class OrdemDeServicoDbContext : DbContext
    {
        public DbSet<OrdemDeServicoDbContext> OrdemDeServicos { get; set; }

        public void Configure(EntityTypeBuilder<OrdemDeServicoDbContext> builder)
        {
            builder.ToTable("OrdemDeServico");
            //builder.HasOne(p => p.Contratante);
            //builder.HasOne(p => p.PrestadorDeServico);
            //builder.HasOne(p => p.ServicoPrestado);
            //builder.HasOne(p => p.Status);
        }
    }
}

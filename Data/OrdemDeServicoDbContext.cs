using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class OrdemDeServicoDbContext : DbContext
    {
        public DbSet<OrdemDeServico> OrdemDeServicos { get; set; }

        public void Configure(EntityTypeBuilder<OrdemDeServico> builder)
        {
            builder.ToTable("OrdemDeServico");

            builder.Property(p => p.DataPrestacao);
            builder.Property(p => p.Preco);
            builder.Property(p => p.Endereco);
            builder.Property(p => p.Resumo);
            builder.Property(p => p.Status);
            builder.Property(p => p.FormaPagamento);            
            
            builder.HasOne(p => p.Prestador);
            builder.HasOne(p => p.ServicoPrestado);
            builder.HasOne(p => p.Contratante);
        }
    }
}

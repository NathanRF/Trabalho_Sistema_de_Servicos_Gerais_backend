using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class ContratanteDbContext : DbContext
    {
        public DbSet<Contratante> Contratantes { get; set; }

        public void Configure(EntityTypeBuilder<Contratante> builder)
        {
            builder.ToTable("Contratante");
            //builder.HasKey(p => p.UserID);
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Password);
            builder.Property(p => p.PasswordHash);
            builder.Property(p => p.NomeCompleto);
            builder.Property(p => p.Endereco);
            builder.Property(p => p.Telefone);
            builder.Property(p => p.LinkFoto);

            //builder.HasOne(p => p.PrestadorDeservico);
            //builder.HasOne(p => p.OrdemDeServico);
        }
    }
}

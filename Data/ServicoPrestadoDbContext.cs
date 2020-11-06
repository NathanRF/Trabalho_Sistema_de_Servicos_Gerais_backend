using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class ServicoPrestadoDbContext : DbContext
    {
        public DbSet<ServicoPrestado> servicoPrestados { get; set; }

        public void Configure(EntityTypeBuilder<ServicoPrestado> builder)
        {
            builder.ToTable("ServicoPrestado");
            //builder.HasKey(p => p.UserID);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Preco);
            //builder.HasMany(p => p.Prestador);
            //builder.HasMany(p => p.Servico);
            builder.HasOne(p => p.Prestador);
            builder.HasOne(p => p.Servico);
            builder.HasOne(p => p.Unidade);
        }
    }
}

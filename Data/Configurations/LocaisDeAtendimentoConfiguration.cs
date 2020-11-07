using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class LocaisDeAtendimentoConfiguration : IEntityTypeConfiguration<LocaisDeAtendimento>
    {
        public void Configure(EntityTypeBuilder<LocaisDeAtendimento> builder)
        {
            builder.ToTable("LocaisDeAtendimento");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Estado);
            builder.Property(p => p.Cidade);
            builder.HasOne(p => p.Prestador);
        }
    }
}

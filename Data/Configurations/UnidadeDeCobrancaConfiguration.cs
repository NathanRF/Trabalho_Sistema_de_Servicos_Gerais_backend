using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class UnidadeDeCobrancaConfiguration : IEntityTypeConfiguration<UnidadeDeCobranca>
    {
        public void Configure(EntityTypeBuilder<UnidadeDeCobranca> builder)
        {
            builder.ToTable("UnidadedeCobranca");
            builder.HasKey(u=>u.Id);
            builder.HasIndex(u=>u.Unidade).IsUnique();
        }
    }
}

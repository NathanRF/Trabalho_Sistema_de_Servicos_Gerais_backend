using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contratante> Contratantes { get; set; }
        public DbSet<LocaisDeAtendimento> LocaisDeAtendimento { get; set; }
        public DbSet<OrdemDeServico> OrdensDeServico { get; set; }
        public DbSet<Prestador> Prestadores { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ServicoPrestado> ServicosPrestados { get; set; }
        public DbSet<UnidadeDeCobranca> UnidadesDeCobranca { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);

            //builder.Entity<LocaisDeAtendimento>().HasData(
            //    new LocaisDeAtendimento
            //    {
            //        Cidade = "Belo Horizonte",
            //        Estado = "Minas Gerais",
            //        Prestador = ''
            //    }
            //);

            builder.Entity<UnidadeDeCobranca>().HasData(
                new UnidadeDeCobranca
                {
                    Id = Guid.NewGuid(),
                    Unidade = "Unidade"
                }
            );

            builder.Entity<UnidadeDeCobranca>().HasData(
                new UnidadeDeCobranca
                {
                    Id = Guid.NewGuid(),
                    Unidade = "Dia"
                }
            );

            builder.Entity<UnidadeDeCobranca>().HasData(
                new UnidadeDeCobranca
                {
                    Id = Guid.NewGuid(),
                    Unidade = "Hora"
                }
            );

            builder.Entity<Servico>().HasData(
                new Servico
                {
                    Id = Guid.NewGuid(),
                    Nome = "Pintor",
                    DescricaoServico = "Ótimo pintor, especialista em desenhos e pinturas artísticas."
                }
            );

            builder.Entity<Servico>().HasData(
                new Servico
                {
                    Id = Guid.NewGuid(),
                    Nome = "Encanador",
                    DescricaoServico = "Especialista em encanamentos e no conserto de vazamentos em geral.."
                }
            );

            //builder.Entity<ServicoPrestado>().HasData(
            //  new ServicoPrestado
            //  {
            //      Preco= 100.0,
            //      Prestador = ,
            //      Servico = ,
            //      Unidade =  
            //  }
            //);

            //builder.Entity<ServicoPrestado>().HasData(
            //    new ServicoPrestado
            //    {
            //        Preco = 100.0,
            //        Unidade = new UnidadeDeCobranca
            //        {
            //            Unidade = "Hora"
            //        },
            //        Servico =  new Servico
            //        {
            //            Nome = "Eletricista",
            //            DescricaoServico = "Eletricista experiênte"
            //        },
            //        Prestador =  new Prestador
            //        {
            //            Biografia = "",
            //            User = 
            //        }
            //    }    
            //);
        }
    }
}

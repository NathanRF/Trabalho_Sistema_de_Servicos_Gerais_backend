﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Bson;
using SSG_API.Domain;

namespace SSG_API.Data
{
    public class PrestadorDbContext : DbContext
    {
        public DbSet<Prestador> Prestadores { get; set; }

        public void Configure(EntityTypeBuilder<Prestador> builder)
        {
            builder.ToTable("Prestador");
            //builder.HasKey(p => p.UserID);
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Password);
            builder.Property(p => p.PasswordHash);
            builder.Property(p => p.NomeCompleto);
            builder.Property(p => p.Endereco);
            builder.Property(p => p.Telefone);
            builder.Property(p => p.LinkFoto);
            builder.Property(p => p.Biografia);

            //builder.HasMany(p => p.OrdemDeServico);
            //builder.HasMany(p => p.Servico); // tem que ver se nã mudou pra um
            //builder.HasMany(p => p.ServicoPrestado);
            //builder.HasMany(p => p.LocaisDeAtendimento);
            //builder.HasMany(p => p.Contratante);
        }
    }
}
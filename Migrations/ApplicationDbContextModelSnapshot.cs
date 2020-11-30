﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSG_API.Data;

namespace SSG_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SSG_API.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<double>("Avaliacao")
                        .HasColumnType("double");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LinkFoto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("SSG_API.Domain.Contratante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contratante");
                });

            modelBuilder.Entity("SSG_API.Domain.LocaisDeAtendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("PrestadorId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PrestadorId");

                    b.ToTable("LocaisDeAtendimento");
                });

            modelBuilder.Entity("SSG_API.Domain.OrdemDeServico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ContratanteId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataPrestacao")
                        .HasColumnType("datetime(6)");
                        
                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("FormaPagamento")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<Guid?>("PrestadorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Resumo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("ServicoPrestadoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContratanteId");

                    b.HasIndex("PrestadorId");

                    b.HasIndex("ServicoPrestadoId");

                    b.ToTable("OrdemDeServico");
                });

            modelBuilder.Entity("SSG_API.Domain.Prestador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Biografia")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Prestador");
                });

            modelBuilder.Entity("SSG_API.Domain.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("DescricaoServico")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Servico");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8cba7429-3e11-4601-a724-15ab293e564b"),
                            DescricaoServico = "Ótimo pintor, especialista em desenhos e pinturas artísticas.",
                            Nome = "PINTOR"
                        },
                        new
                        {
                            Id = new Guid("a5f55959-6d6b-42fe-a74e-2e5280eae028"),
                            DescricaoServico = "Especialista em encanamentos e no conserto de vazamentos em geral..",
                            Nome = "ENCANADOR"
                        });
                });

            modelBuilder.Entity("SSG_API.Domain.ServicoPrestado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<Guid?>("PrestadorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ServicoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UnidadeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PrestadorId");

                    b.HasIndex("ServicoId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("ServicoPrestado");
                });

            modelBuilder.Entity("SSG_API.Domain.UnidadeDeCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Unidade")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Unidade")
                        .IsUnique();

                    b.ToTable("UnidadedeCobranca");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a80f9265-4751-4cad-ac27-09e62ff4a342"),
                            Unidade = "Unidade"
                        },
                        new
                        {
                            Id = new Guid("2635b394-906d-4376-9e40-44f1e4d5884e"),
                            Unidade = "Dia"
                        },
                        new
                        {
                            Id = new Guid("95949a93-372e-422b-9973-62ad3327a5c6"),
                            Unidade = "Hora"
                        });
                });

            modelBuilder.Entity("SSG_API.Domain.Contratante", b =>
                {
                    b.HasOne("SSG_API.Domain.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SSG_API.Domain.LocaisDeAtendimento", b =>
                {
                    b.HasOne("SSG_API.Domain.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("PrestadorId");
                });

            modelBuilder.Entity("SSG_API.Domain.OrdemDeServico", b =>
                {
                    b.HasOne("SSG_API.Domain.Contratante", "Contratante")
                        .WithMany()
                        .HasForeignKey("ContratanteId");

                    b.HasOne("SSG_API.Domain.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("PrestadorId");

                    b.HasOne("SSG_API.Domain.ServicoPrestado", "ServicoPrestado")
                        .WithMany()
                        .HasForeignKey("ServicoPrestadoId");
                });

            modelBuilder.Entity("SSG_API.Domain.Prestador", b =>
                {
                    b.HasOne("SSG_API.Domain.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SSG_API.Domain.ServicoPrestado", b =>
                {
                    b.HasOne("SSG_API.Domain.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("PrestadorId");

                    b.HasOne("SSG_API.Domain.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId");

                    b.HasOne("SSG_API.Domain.UnidadeDeCobranca", "Unidade")
                        .WithMany()
                        .HasForeignKey("UnidadeId");
                });
#pragma warning restore 612, 618
        }
    }
}

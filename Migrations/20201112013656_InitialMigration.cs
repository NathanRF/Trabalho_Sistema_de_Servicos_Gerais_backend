using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSG_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NomeCompleto = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    LinkFoto = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Avaliacao = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DescricaoServico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadedeCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Unidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadedeCobranca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratante_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Biografia = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestador_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocaisDeAtendimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrestadorId = table.Column<Guid>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocaisDeAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocaisDeAtendimento_Prestador_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicoPrestado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServicoId = table.Column<Guid>(nullable: true),
                    PrestadorId = table.Column<Guid>(nullable: true),
                    UnidadeId = table.Column<Guid>(nullable: true),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoPrestado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicoPrestado_Prestador_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicoPrestado_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicoPrestado_UnidadedeCobranca_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "UnidadedeCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdemDeServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrestadorId = table.Column<Guid>(nullable: true),
                    ContratanteId = table.Column<Guid>(nullable: true),
                    ServicoPrestadoId = table.Column<Guid>(nullable: true),
                    DataPrestacao = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Resumo = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    FormaPagamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemDeServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_Contratante_ContratanteId",
                        column: x => x.ContratanteId,
                        principalTable: "Contratante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_Prestador_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_ServicoPrestado_ServicoPrestadoId",
                        column: x => x.ServicoPrestadoId,
                        principalTable: "ServicoPrestado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Servico",
                columns: new[] { "Id", "DescricaoServico", "Nome" },
                values: new object[,]
                {
                    { new Guid("ea0704ab-c58c-41cd-ac71-3b59f2e171b2"), "Ótimo pintor, especialista em desenhos e pinturas artísticas.", "PINTOR" },
                    { new Guid("55f55cda-42fe-4f3e-8753-b1ac0b73b0e0"), "Especialista em encanamentos e no conserto de vazamentos em geral..", "ENCANADOR" }
                });

            migrationBuilder.InsertData(
                table: "UnidadedeCobranca",
                columns: new[] { "Id", "Unidade" },
                values: new object[,]
                {
                    { new Guid("62e05296-1513-4105-8b96-06a9494c91f5"), "Unidade" },
                    { new Guid("e52a72a7-0cf4-4d63-9ff9-1defddadc1a6"), "Dia" },
                    { new Guid("c789afba-514a-489c-897c-2b3530a9d26b"), "Hora" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratante_UserId",
                table: "Contratante",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LocaisDeAtendimento_PrestadorId",
                table: "LocaisDeAtendimento",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_ContratanteId",
                table: "OrdemDeServico",
                column: "ContratanteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_PrestadorId",
                table: "OrdemDeServico",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_ServicoPrestadoId",
                table: "OrdemDeServico",
                column: "ServicoPrestadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestador_UserId",
                table: "Prestador",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_Nome",
                table: "Servico",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicoPrestado_PrestadorId",
                table: "ServicoPrestado",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoPrestado_ServicoId",
                table: "ServicoPrestado",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoPrestado_UnidadeId",
                table: "ServicoPrestado",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadedeCobranca_Unidade",
                table: "UnidadedeCobranca",
                column: "Unidade",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocaisDeAtendimento");

            migrationBuilder.DropTable(
                name: "OrdemDeServico");

            migrationBuilder.DropTable(
                name: "Contratante");

            migrationBuilder.DropTable(
                name: "ServicoPrestado");

            migrationBuilder.DropTable(
                name: "Prestador");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "UnidadedeCobranca");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}

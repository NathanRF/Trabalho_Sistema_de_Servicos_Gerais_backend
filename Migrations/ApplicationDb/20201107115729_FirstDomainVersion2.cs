using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSG_API.Migrations.ApplicationDb
{
    public partial class FirstDomainVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unidade",
                table: "UnidadedeCobranca",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Servico",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Servico",
                columns: new[] { "Id", "DescricaoServico", "Nome" },
                values: new object[,]
                {
                    { new Guid("fc75c5ef-3bde-4e19-8b4c-8ebfee00d020"), "Ótimo pintor, especialista em desenhos e pinturas artísticas.", "PINTOR" },
                    { new Guid("5e6d40a2-233f-4c61-9af3-1ebfce5ecca6"), "Especialista em encanamentos e no conserto de vazamentos em geral..", "ENCANADOR" }
                });

            migrationBuilder.InsertData(
                table: "UnidadedeCobranca",
                columns: new[] { "Id", "Unidade" },
                values: new object[,]
                {
                    { new Guid("2ac1b709-d89b-4e95-b915-f2975764e9e5"), "Unidade" },
                    { new Guid("35f56926-0350-49db-bd6e-51258322b7ae"), "Dia" },
                    { new Guid("5f29a020-1b9e-4cc5-9e08-f0eba64dec7b"), "Hora" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnidadedeCobranca_Unidade",
                table: "UnidadedeCobranca",
                column: "Unidade",
                unique: true,
                filter: "[Unidade] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_Nome",
                table: "Servico",
                column: "Nome",
                unique: true,
                filter: "[Nome] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UnidadedeCobranca_Unidade",
                table: "UnidadedeCobranca");

            migrationBuilder.DropIndex(
                name: "IX_Servico_Nome",
                table: "Servico");

            migrationBuilder.DeleteData(
                table: "Servico",
                keyColumn: "Id",
                keyValue: new Guid("5e6d40a2-233f-4c61-9af3-1ebfce5ecca6"));

            migrationBuilder.DeleteData(
                table: "Servico",
                keyColumn: "Id",
                keyValue: new Guid("fc75c5ef-3bde-4e19-8b4c-8ebfee00d020"));

            migrationBuilder.DeleteData(
                table: "UnidadedeCobranca",
                keyColumn: "Id",
                keyValue: new Guid("2ac1b709-d89b-4e95-b915-f2975764e9e5"));

            migrationBuilder.DeleteData(
                table: "UnidadedeCobranca",
                keyColumn: "Id",
                keyValue: new Guid("35f56926-0350-49db-bd6e-51258322b7ae"));

            migrationBuilder.DeleteData(
                table: "UnidadedeCobranca",
                keyColumn: "Id",
                keyValue: new Guid("5f29a020-1b9e-4cc5-9e08-f0eba64dec7b"));

            migrationBuilder.AlterColumn<string>(
                name: "Unidade",
                table: "UnidadedeCobranca",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Servico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

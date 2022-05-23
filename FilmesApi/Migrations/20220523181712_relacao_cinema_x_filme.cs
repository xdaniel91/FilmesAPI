using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class relacao_cinema_x_filme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cinemas_gerentes_GerenteId",
                table: "cinemas");

            migrationBuilder.CreateTable(
                name: "sessoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmeId = table.Column<int>(type: "integer", nullable: false),
                    CinemaId = table.Column<int>(type: "integer", nullable: false),
                    HorarioEncerramento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sessoes_cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sessoes_filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sessoes_CinemaId",
                table: "sessoes",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_sessoes_FilmeId",
                table: "sessoes",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_cinemas_gerentes_GerenteId",
                table: "cinemas",
                column: "GerenteId",
                principalTable: "gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cinemas_gerentes_GerenteId",
                table: "cinemas");

            migrationBuilder.DropTable(
                name: "sessoes");

            migrationBuilder.AddForeignKey(
                name: "FK_cinemas_gerentes_GerenteId",
                table: "cinemas",
                column: "GerenteId",
                principalTable: "gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

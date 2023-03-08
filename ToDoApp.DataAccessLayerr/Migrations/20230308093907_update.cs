using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preferiti",
                columns: table => new
                {
                    listaPreferitiId = table.Column<int>(type: "int", nullable: false),
                    listaUtentiConPreferitoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferiti", x => new { x.listaPreferitiId, x.listaUtentiConPreferitoId });
                    table.ForeignKey(
                        name: "FK_Preferiti_Programma_listaPreferitiId",
                        column: x => x.listaPreferitiId,
                        principalTable: "Programma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferiti_users_listaUtentiConPreferitoId",
                        column: x => x.listaUtentiConPreferitoId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preferiti_listaUtentiConPreferitoId",
                table: "Preferiti",
                column: "listaUtentiConPreferitoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preferiti");

            migrationBuilder.DropTable(
                name: "Programma");
        }
    }
}

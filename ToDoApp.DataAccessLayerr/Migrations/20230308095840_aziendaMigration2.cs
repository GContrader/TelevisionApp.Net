using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class aziendaMigration2 : Migration
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
                    Orario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AziendaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programma_azienda_AziendaId",
                        column: x => x.AziendaId,
                        principalTable: "azienda",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programma_AziendaId",
                table: "Programma",
                column: "AziendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programma");
        }
    }
}

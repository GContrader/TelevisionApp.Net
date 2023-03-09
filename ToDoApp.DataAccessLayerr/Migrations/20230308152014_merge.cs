using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class merge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AziendaId",
                table: "Programma",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programma_AziendaId",
                table: "Programma",
                column: "AziendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programma_azienda_AziendaId",
                table: "Programma",
                column: "AziendaId",
                principalTable: "azienda",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programma_azienda_AziendaId",
                table: "Programma");

            migrationBuilder.DropIndex(
                name: "IX_Programma_AziendaId",
                table: "Programma");

            migrationBuilder.DropColumn(
                name: "AziendaId",
                table: "Programma");
        }
    }
}

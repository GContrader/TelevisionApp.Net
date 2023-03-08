using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todoItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    lastmodified = table.Column<DateTime>(name: "last_modified", type: "date", nullable: false),
                    iscomplete = table.Column<bool>(name: "is_complete", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__todoItem__3213E83F8102F018", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todoItems");
        }
    }
}

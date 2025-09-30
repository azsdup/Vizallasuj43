using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vizallasuj2.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_493 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vízállás",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Vizallas = table.Column<int>(type: "INTEGER", nullable: false),
                    Varos = table.Column<string>(type: "TEXT", nullable: false),
                    Folyo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vízállás", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vízállás");
        }
    }
}

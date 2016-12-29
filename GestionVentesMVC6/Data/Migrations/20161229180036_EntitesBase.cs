using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestionVentesMVC6.Data.Migrations
{
    public partial class EntitesBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compagnie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compagnie", x => x.ID);
                });

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "TypeAssurance",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compagnie");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "TypeAssurance",
                nullable: true);
        }
    }
}

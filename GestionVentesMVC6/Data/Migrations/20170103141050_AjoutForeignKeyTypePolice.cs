using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionVentesMVC6.Data.Migrations
{
    public partial class AjoutForeignKeyTypePolice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vente_TypePoliceID",
                table: "Vente",
                column: "TypePoliceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vente_TypePolice_TypePoliceID",
                table: "Vente",
                column: "TypePoliceID",
                principalTable: "TypePolice",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vente_TypePolice_TypePoliceID",
                table: "Vente");

            migrationBuilder.DropIndex(
                name: "IX_Vente_TypePoliceID",
                table: "Vente");
        }
    }
}

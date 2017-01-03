using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionVentesMVC6.Data.Migrations
{
    public partial class VentesFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Vente",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompagnieID",
                table: "Vente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateVente",
                table: "Vente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "MontantPrimeTotal",
                table: "Vente",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PourcentageCommission",
                table: "Vente",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Vente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendeurID",
                table: "Vente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vente_CompagnieID",
                table: "Vente",
                column: "CompagnieID");

            migrationBuilder.CreateIndex(
                name: "IX_Vente_TypeAssuranceID",
                table: "Vente",
                column: "TypeAssuranceID");

            migrationBuilder.CreateIndex(
                name: "IX_Vente_VendeurID",
                table: "Vente",
                column: "VendeurID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vente_Compagnie_CompagnieID",
                table: "Vente",
                column: "CompagnieID",
                principalTable: "Compagnie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vente_TypeAssurance_TypeAssuranceID",
                table: "Vente",
                column: "TypeAssuranceID",
                principalTable: "TypeAssurance",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vente_Vendeur_VendeurID",
                table: "Vente",
                column: "VendeurID",
                principalTable: "Vendeur",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vente_Compagnie_CompagnieID",
                table: "Vente");

            migrationBuilder.DropForeignKey(
                name: "FK_Vente_TypeAssurance_TypeAssuranceID",
                table: "Vente");

            migrationBuilder.DropForeignKey(
                name: "FK_Vente_Vendeur_VendeurID",
                table: "Vente");

            migrationBuilder.DropIndex(
                name: "IX_Vente_CompagnieID",
                table: "Vente");

            migrationBuilder.DropIndex(
                name: "IX_Vente_TypeAssuranceID",
                table: "Vente");

            migrationBuilder.DropIndex(
                name: "IX_Vente_VendeurID",
                table: "Vente");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "Vente");

            migrationBuilder.DropColumn(
                name: "CompagnieID",
                table: "Vente");

            migrationBuilder.DropColumn(
                name: "DateVente",
                table: "Vente");

            migrationBuilder.DropColumn(
                name: "MontantPrimeTotal",
                table: "Vente");

            migrationBuilder.DropColumn(
                name: "PourcentageCommission",
                table: "Vente");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Vente");

            migrationBuilder.DropColumn(
                name: "VendeurID",
                table: "Vente");
        }
    }
}

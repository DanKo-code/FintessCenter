using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Migrations
{
    /// <inheritdoc />
    public partial class deletedirtidcolumninServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbonementsServices_Abonements_AbonementId",
                table: "AbonementsServices");

            migrationBuilder.DropColumn(
                name: "AbonementId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "AbonementId",
                table: "AbonementsServices",
                newName: "AbonementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbonementsServices_Abonements_AbonementsId",
                table: "AbonementsServices",
                column: "AbonementsId",
                principalTable: "Abonements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbonementsServices_Abonements_AbonementsId",
                table: "AbonementsServices");

            migrationBuilder.RenameColumn(
                name: "AbonementsId",
                table: "AbonementsServices",
                newName: "AbonementId");

            migrationBuilder.AddColumn<Guid>(
                name: "AbonementId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_AbonementsServices_Abonements_AbonementId",
                table: "AbonementsServices",
                column: "AbonementId",
                principalTable: "Abonements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Migrations
{
    /// <inheritdoc />
    public partial class testservices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Abonements_AbonementsId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_AbonementsId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "AbonementsId",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "AbonementsServices",
                columns: table => new
                {
                    AbonementsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonementsServices", x => new { x.AbonementsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_AbonementsServices_Abonements_AbonementsId",
                        column: x => x.AbonementsId,
                        principalTable: "Abonements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbonementsServices_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbonementsServices_ServicesId",
                table: "AbonementsServices",
                column: "ServicesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonementsServices");

            migrationBuilder.AddColumn<Guid>(
                name: "AbonementsId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_AbonementsId",
                table: "Services",
                column: "AbonementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Abonements_AbonementsId",
                table: "Services",
                column: "AbonementsId",
                principalTable: "Abonements",
                principalColumn: "Id");
        }
    }
}

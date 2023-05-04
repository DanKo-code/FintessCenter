using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "Clients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AbonementsId",
                table: "Abonements",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "ClientsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Abonements",
                newName: "AbonementsId");
        }
    }
}

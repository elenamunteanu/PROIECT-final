using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations
{
    public partial class patru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinatieID",
                table: "Plecari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plecari_DestinatieID",
                table: "Plecari",
                column: "DestinatieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plecari_Destinatie_DestinatieID",
                table: "Plecari",
                column: "DestinatieID",
                principalTable: "Destinatie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plecari_Destinatie_DestinatieID",
                table: "Plecari");

            migrationBuilder.DropIndex(
                name: "IX_Plecari_DestinatieID",
                table: "Plecari");

            migrationBuilder.DropColumn(
                name: "DestinatieID",
                table: "Plecari");
        }
    }
}

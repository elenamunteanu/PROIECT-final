using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations
{
    public partial class cinci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanieID",
                table: "Sosiri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanieID",
                table: "Plecari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCompanie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sosiri_CompanieID",
                table: "Sosiri",
                column: "CompanieID");

            migrationBuilder.CreateIndex(
                name: "IX_Plecari_CompanieID",
                table: "Plecari",
                column: "CompanieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plecari_Companie_CompanieID",
                table: "Plecari",
                column: "CompanieID",
                principalTable: "Companie",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sosiri_Companie_CompanieID",
                table: "Sosiri",
                column: "CompanieID",
                principalTable: "Companie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plecari_Companie_CompanieID",
                table: "Plecari");

            migrationBuilder.DropForeignKey(
                name: "FK_Sosiri_Companie_CompanieID",
                table: "Sosiri");

            migrationBuilder.DropTable(
                name: "Companie");

            migrationBuilder.DropIndex(
                name: "IX_Sosiri_CompanieID",
                table: "Sosiri");

            migrationBuilder.DropIndex(
                name: "IX_Plecari_CompanieID",
                table: "Plecari");

            migrationBuilder.DropColumn(
                name: "CompanieID",
                table: "Sosiri");

            migrationBuilder.DropColumn(
                name: "CompanieID",
                table: "Plecari");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations
{
    public partial class trei : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinatieID",
                table: "Sosiri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Destinatie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireOras = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinatie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sosiri_DestinatieID",
                table: "Sosiri",
                column: "DestinatieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sosiri_Destinatie_DestinatieID",
                table: "Sosiri",
                column: "DestinatieID",
                principalTable: "Destinatie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sosiri_Destinatie_DestinatieID",
                table: "Sosiri");

            migrationBuilder.DropTable(
                name: "Destinatie");

            migrationBuilder.DropIndex(
                name: "IX_Sosiri_DestinatieID",
                table: "Sosiri");

            migrationBuilder.DropColumn(
                name: "DestinatieID",
                table: "Sosiri");
        }
    }
}

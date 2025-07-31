using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediatorCrud.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ctgries",
                columns: table => new
                {
                    catgryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catgryNmae = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ctgries", x => x.catgryId);
                });

            migrationBuilder.CreateTable(
                name: "Pdts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdtStk = table.Column<int>(type: "int", nullable: false),
                    PdtDescr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdtPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    catgryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pdts_Ctgries_catgryId",
                        column: x => x.catgryId,
                        principalTable: "Ctgries",
                        principalColumn: "catgryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ctgries",
                columns: new[] { "catgryId", "catgryNmae" },
                values: new object[,]
                {
                    { 1, "Mobile" },
                    { 2, "Laptop" },
                    { 3, "TV" },
                    { 4, "Audio" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pdts_catgryId",
                table: "Pdts",
                column: "catgryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pdts");

            migrationBuilder.DropTable(
                name: "Ctgries");
        }
    }
}

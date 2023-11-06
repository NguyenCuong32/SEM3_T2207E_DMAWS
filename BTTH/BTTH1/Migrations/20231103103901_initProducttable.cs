using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTTH1.Migrations
{
    /// <inheritdoc />
    public partial class initProducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandModels",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandModels", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryModels",
                columns: table => new
                {
                    CateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CateDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CateOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModels", x => x.CateId);
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CateId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductModels_BrandModels_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BrandModels",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModels_CategoryModels_CateId",
                        column: x => x.CateId,
                        principalTable: "CategoryModels",
                        principalColumn: "CateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_BrandId",
                table: "ProductModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_CateId",
                table: "ProductModels",
                column: "CateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "BrandModels");

            migrationBuilder.DropTable(
                name: "CategoryModels");
        }
    }
}

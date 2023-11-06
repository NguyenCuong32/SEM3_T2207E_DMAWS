using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTTH2.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User_Tbl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Tbl",
                table: "User_Tbl",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "Brand_Tbl",
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
                    table.PrimaryKey("PK_Brand_Tbl", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Cate_Tbl",
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
                    table.PrimaryKey("PK_Cate_Tbl", x => x.CateId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Tbl",
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
                    table.PrimaryKey("PK_Product_Tbl", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Tbl_Brand_Tbl_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand_Tbl",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Tbl_Cate_Tbl_CateId",
                        column: x => x.CateId,
                        principalTable: "Cate_Tbl",
                        principalColumn: "CateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Tbl_BrandId",
                table: "Product_Tbl",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Tbl_CateId",
                table: "Product_Tbl",
                column: "CateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Tbl");

            migrationBuilder.DropTable(
                name: "Brand_Tbl");

            migrationBuilder.DropTable(
                name: "Cate_Tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Tbl",
                table: "User_Tbl");

            migrationBuilder.RenameTable(
                name: "User_Tbl",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");
        }
    }
}

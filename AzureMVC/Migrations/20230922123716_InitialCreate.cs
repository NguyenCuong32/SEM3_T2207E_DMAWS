using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhamNgocDung.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department_Tbl",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentNumbPersonals = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Tbl", x => x.departmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Tbl",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeCode = table.Column<int>(type: "int", nullable: false),
                    employeeDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeePassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Tbl", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Tbl_Department_Tbl_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Department_Tbl",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false),
                Name = table.Column<string>(nullable: true),
                Email = table.Column<string>(nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Tbl_departmentId",
                table: "Employee_Tbl",
                column: "departmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee_Tbl");

            migrationBuilder.DropTable(
                name: "Department_Tbl");
        }
    }
}

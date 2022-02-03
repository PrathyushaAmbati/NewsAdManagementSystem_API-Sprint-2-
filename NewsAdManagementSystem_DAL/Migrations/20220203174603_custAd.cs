using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAdManagementSystem_DAL.Migrations
{
    public partial class custAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAdDetails",
                columns: table => new
                {
                    SNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpID = table.Column<int>(type: "int", nullable: false),
                    CustID = table.Column<int>(type: "int", nullable: false),
                    AdCode = table.Column<int>(type: "int", nullable: false),
                    DOI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitCost = table.Column<int>(type: "int", nullable: false),
                    AdvtSizesqcm = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    PageStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdDetails", x => x.SNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAdDetails");
        }
    }
}

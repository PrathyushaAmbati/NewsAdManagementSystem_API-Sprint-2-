using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAdManagementSystem_DAL.Migrations
{
    public partial class mvc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pwd",
                table: "CustomerDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pwd",
                table: "CustomerDetails");
        }
    }
}

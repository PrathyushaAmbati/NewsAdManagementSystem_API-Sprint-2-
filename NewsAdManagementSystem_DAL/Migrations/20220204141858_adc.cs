using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsAdManagementSystem_DAL.Migrations
{
    public partial class adc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerDetailsCustID",
                table: "CustomerAdDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDetailsEmpID",
                table: "CustomerAdDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "advertisementDetailsAdCode",
                table: "CustomerAdDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdDetails_advertisementDetailsAdCode",
                table: "CustomerAdDetails",
                column: "advertisementDetailsAdCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdDetails_CustomerDetailsCustID",
                table: "CustomerAdDetails",
                column: "CustomerDetailsCustID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdDetails_EmployeeDetailsEmpID",
                table: "CustomerAdDetails",
                column: "EmployeeDetailsEmpID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAdDetails_AdvertisementDetails_advertisementDetailsAdCode",
                table: "CustomerAdDetails",
                column: "advertisementDetailsAdCode",
                principalTable: "AdvertisementDetails",
                principalColumn: "AdCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAdDetails_CustomerDetails_CustomerDetailsCustID",
                table: "CustomerAdDetails",
                column: "CustomerDetailsCustID",
                principalTable: "CustomerDetails",
                principalColumn: "CustID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAdDetails_EmployeeDetails_EmployeeDetailsEmpID",
                table: "CustomerAdDetails",
                column: "EmployeeDetailsEmpID",
                principalTable: "EmployeeDetails",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAdDetails_AdvertisementDetails_advertisementDetailsAdCode",
                table: "CustomerAdDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAdDetails_CustomerDetails_CustomerDetailsCustID",
                table: "CustomerAdDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAdDetails_EmployeeDetails_EmployeeDetailsEmpID",
                table: "CustomerAdDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAdDetails_advertisementDetailsAdCode",
                table: "CustomerAdDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAdDetails_CustomerDetailsCustID",
                table: "CustomerAdDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAdDetails_EmployeeDetailsEmpID",
                table: "CustomerAdDetails");

            migrationBuilder.DropColumn(
                name: "CustomerDetailsCustID",
                table: "CustomerAdDetails");

            migrationBuilder.DropColumn(
                name: "EmployeeDetailsEmpID",
                table: "CustomerAdDetails");

            migrationBuilder.DropColumn(
                name: "advertisementDetailsAdCode",
                table: "CustomerAdDetails");
        }
    }
}

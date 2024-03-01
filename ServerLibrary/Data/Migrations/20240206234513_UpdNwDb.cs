using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdNwDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Customers_CustomerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CustomerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CustomerId",
                table: "Employees",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Customers_CustomerId",
                table: "Employees",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

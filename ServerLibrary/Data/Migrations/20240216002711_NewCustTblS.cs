using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewCustTblS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cust_PaymentTypes_PaymentTypeId",
                table: "Cust");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cust",
                table: "Cust");

            migrationBuilder.RenameTable(
                name: "Cust",
                newName: "Custs");

            migrationBuilder.RenameIndex(
                name: "IX_Cust_PaymentTypeId",
                table: "Custs",
                newName: "IX_Custs_PaymentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Custs",
                table: "Custs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Custs_PaymentTypes_PaymentTypeId",
                table: "Custs",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Custs_PaymentTypes_PaymentTypeId",
                table: "Custs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Custs",
                table: "Custs");

            migrationBuilder.RenameTable(
                name: "Custs",
                newName: "Cust");

            migrationBuilder.RenameIndex(
                name: "IX_Custs_PaymentTypeId",
                table: "Cust",
                newName: "IX_Cust_PaymentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cust",
                table: "Cust",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cust_PaymentTypes_PaymentTypeId",
                table: "Cust",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

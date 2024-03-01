using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewCustTblSUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Custs_PaymentTypes_PaymentTypeId",
                table: "Custs");

            migrationBuilder.DropIndex(
                name: "IX_Custs_PaymentTypeId",
                table: "Custs");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Custs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Custs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Custs_PaymentTypeId",
                table: "Custs",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Custs_PaymentTypes_PaymentTypeId",
                table: "Custs",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

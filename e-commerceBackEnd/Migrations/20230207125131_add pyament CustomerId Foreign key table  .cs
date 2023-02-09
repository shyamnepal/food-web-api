using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceBackEnd.Migrations.NormalDb
{
    /// <inheritdoc />
    public partial class addpyamentCustomerIdForeignkeytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "tbl_Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Payment_CustomerId",
                table: "tbl_Payment",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Payment_tbl_Customer_CustomerId",
                table: "tbl_Payment",
                column: "CustomerId",
                principalTable: "tbl_Customer",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Payment_tbl_Customer_CustomerId",
                table: "tbl_Payment");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Payment_CustomerId",
                table: "tbl_Payment");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "tbl_Payment");
        }
    }
}

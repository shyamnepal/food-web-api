using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceBackEnd.Migrations.NormalDb
{
    /// <inheritdoc />
    public partial class addpyamentorderIdForeignkeytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "paymentId",
                table: "tbl_Payment",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "tbl_Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Payment_orderId",
                table: "tbl_Payment",
                column: "orderId",
                unique: true,
                filter: "[orderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Payment_tbl_Order_orderId",
                table: "tbl_Payment",
                column: "orderId",
                principalTable: "tbl_Order",
                principalColumn: "orderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Payment_tbl_Order_orderId",
                table: "tbl_Payment");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Payment_orderId",
                table: "tbl_Payment");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "tbl_Payment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_Payment",
                newName: "paymentId");
        }
    }
}

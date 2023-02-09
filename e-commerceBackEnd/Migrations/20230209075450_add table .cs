using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceBackEnd.Migrations.NormalDb
{
    /// <inheritdoc />
    public partial class addtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_Menu_foodId",
                table: "tbl_Menu",
                column: "foodId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Menu_tbl_FoodItem_foodId",
                table: "tbl_Menu",
                column: "foodId",
                principalTable: "tbl_FoodItem",
                principalColumn: "foodId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Menu_tbl_FoodItem_foodId",
                table: "tbl_Menu");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Menu_foodId",
                table: "tbl_Menu");
        }
    }
}

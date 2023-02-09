using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceBackEnd.Migrations.NormalDb
{
    /// <inheritdoc />
    public partial class removetablecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Menu_tbl_FoodItem_FoodItemfoodId",
                table: "tbl_Menu");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Menu_FoodItemfoodId",
                table: "tbl_Menu");

            migrationBuilder.DropColumn(
                name: "FoodItemfoodId",
                table: "tbl_Menu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodItemfoodId",
                table: "tbl_Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Menu_FoodItemfoodId",
                table: "tbl_Menu",
                column: "FoodItemfoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Menu_tbl_FoodItem_FoodItemfoodIdtable",
                table: "tbl_Menu",
                column: "FoodItemfoodId",
                principalTable: "tbl_FoodItem",
                principalColumn: "foodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

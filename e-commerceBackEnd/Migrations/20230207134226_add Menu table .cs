using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceBackEnd.Migrations.NormalDb
{
    /// <inheritdoc />
    public partial class addMenutable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Menu",
                columns: table => new
                {
                    menuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<double>(type: "float", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoodItemfoodId = table.Column<int>(type: "int", nullable: false),
                    foodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Menu", x => x.menuId);
                    table.ForeignKey(
                        name: "FK_tbl_Menu_tbl_FoodItem_FoodItemfoodId",
                        column: x => x.FoodItemfoodId,
                        principalTable: "tbl_FoodItem",
                        principalColumn: "foodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Menu_FoodItemfoodId",
                table: "tbl_Menu",
                column: "FoodItemfoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Menu");
        }
    }
}

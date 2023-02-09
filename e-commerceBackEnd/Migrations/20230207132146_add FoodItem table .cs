using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceBackEnd.Migrations.NormalDb
{
    /// <inheritdoc />
    public partial class addFoodItemtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_Payment",
                newName: "paymentId");

            migrationBuilder.CreateTable(
                name: "tbl_FoodItem",
                columns: table => new
                {
                    foodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unitPrice = table.Column<double>(type: "float", nullable: false),
                    itemCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foodImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FoodItem", x => x.foodId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_FoodItem");

            migrationBuilder.RenameColumn(
                name: "paymentId",
                table: "tbl_Payment",
                newName: "Id");
        }
    }
}

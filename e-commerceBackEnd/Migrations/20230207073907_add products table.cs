using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class addproductstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Products",
                table: "tbl_Products");

            migrationBuilder.RenameTable(
                name: "tbl_Products",
                newName: "tbl_products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_products",
                table: "tbl_products",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_products",
                table: "tbl_products");

            migrationBuilder.RenameTable(
                name: "tbl_products",
                newName: "tbl_Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Products",
                table: "tbl_Products",
                column: "id");
        }
    }
}

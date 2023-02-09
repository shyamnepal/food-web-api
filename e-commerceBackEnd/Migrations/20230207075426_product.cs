using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_products",
                table: "tbl_products");

            migrationBuilder.RenameTable(
                name: "tbl_products",
                newName: "product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "tbl_products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_products",
                table: "tbl_products",
                column: "id");
        }
    }
}

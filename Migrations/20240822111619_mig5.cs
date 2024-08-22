using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "ShopCarts",
                newName: "ShopCartTotal");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShopCarts",
                newName: "ShopCartQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopCartTotal",
                table: "ShopCarts",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "ShopCartQuantity",
                table: "ShopCarts",
                newName: "Quantity");
        }
    }
}

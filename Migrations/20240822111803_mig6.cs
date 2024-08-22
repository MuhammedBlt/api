using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderQuantity",
                table: "OrderDetails",
                newName: "Total");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "OrderDetails",
                newName: "OrderQuantity");
        }
    }
}

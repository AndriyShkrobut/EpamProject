using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Data.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "CartItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CartID",
                table: "CartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "CartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartID",
                table: "CartItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

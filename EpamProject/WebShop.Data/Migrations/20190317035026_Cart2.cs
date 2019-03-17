using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Data.Migrations
{
    public partial class Cart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "CartID",
                table: "CartItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "CartID",
                table: "CartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

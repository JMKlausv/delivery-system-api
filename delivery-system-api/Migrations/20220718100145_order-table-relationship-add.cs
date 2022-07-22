using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace delivery_system_api.Migrations
{
    public partial class ordertablerelationshipadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderAddressId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ViechleId",
                table: "Orders",
                column: "ViechleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductItems_ProductId",
                table: "OrderProductItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAddresses_OrderId",
                table: "OrderAddresses",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAddresses_Orders_OrderId",
                table: "OrderAddresses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductItems_products_ProductId",
                table: "OrderProductItems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_viechles_ViechleId",
                table: "Orders",
                column: "ViechleId",
                principalTable: "viechles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAddresses_Orders_OrderId",
                table: "OrderAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductItems_products_ProductId",
                table: "OrderProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_viechles_ViechleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ViechleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductItems_ProductId",
                table: "OrderProductItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderAddresses_OrderId",
                table: "OrderAddresses");

            migrationBuilder.AddColumn<int>(
                name: "OrderAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

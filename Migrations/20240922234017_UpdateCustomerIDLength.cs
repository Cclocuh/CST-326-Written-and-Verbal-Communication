using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineGroceryStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerIDLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_CustomerID1",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CustomerID1",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CustomerID1",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Carts",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerID",
                table: "Carts",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_CustomerID",
                table: "Carts",
                column: "CustomerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_CustomerID",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CustomerID",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Carts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID1",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerID1",
                table: "Carts",
                column: "CustomerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_CustomerID1",
                table: "Carts",
                column: "CustomerID1",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

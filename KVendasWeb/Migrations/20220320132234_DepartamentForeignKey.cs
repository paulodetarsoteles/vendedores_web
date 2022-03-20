using Microsoft.EntityFrameworkCore.Migrations;

namespace KVendasWeb.Migrations
{
    public partial class DepartamentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departament_DepartamentId",
                table: "Seller");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Seller",
                newName: "DepartamentID");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_DepartamentId",
                table: "Seller",
                newName: "IX_Seller_DepartamentID");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentID",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departament_DepartamentID",
                table: "Seller",
                column: "DepartamentID",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departament_DepartamentID",
                table: "Seller");

            migrationBuilder.RenameColumn(
                name: "DepartamentID",
                table: "Seller",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_DepartamentID",
                table: "Seller",
                newName: "IX_Seller_DepartamentId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentId",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departament_DepartamentId",
                table: "Seller",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

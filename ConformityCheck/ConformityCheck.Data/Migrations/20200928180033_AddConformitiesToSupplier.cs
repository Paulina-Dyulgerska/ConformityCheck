using Microsoft.EntityFrameworkCore.Migrations;

namespace ConformityCheck.Data.Migrations
{
    public partial class AddConformitiesToSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conformities_Suppliers_SupplierId",
                table: "Conformities");

            migrationBuilder.AddForeignKey(
                name: "FK_Conformities_Suppliers_SupplierId",
                table: "Conformities",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conformities_Suppliers_SupplierId",
                table: "Conformities");

            migrationBuilder.AddForeignKey(
                name: "FK_Conformities_Suppliers_SupplierId",
                table: "Conformities",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

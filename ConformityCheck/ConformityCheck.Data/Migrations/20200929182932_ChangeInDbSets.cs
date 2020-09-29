using Microsoft.EntityFrameworkCore.Migrations;

namespace ConformityCheck.Data.Migrations
{
    public partial class ChangeInDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleConformity_Articles_ArticleId",
                table: "ArticleConformity");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleConformity_Conformities_ConformityId",
                table: "ArticleConformity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleConformity",
                table: "ArticleConformity");

            migrationBuilder.RenameTable(
                name: "ArticleConformity",
                newName: "ArticleConformities");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleConformity_ConformityId",
                table: "ArticleConformities",
                newName: "IX_ArticleConformities_ConformityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleConformities",
                table: "ArticleConformities",
                columns: new[] { "ArticleId", "ConformityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleConformities_Articles_ArticleId",
                table: "ArticleConformities",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleConformities_Conformities_ConformityId",
                table: "ArticleConformities",
                column: "ConformityId",
                principalTable: "Conformities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleConformities_Articles_ArticleId",
                table: "ArticleConformities");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleConformities_Conformities_ConformityId",
                table: "ArticleConformities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleConformities",
                table: "ArticleConformities");

            migrationBuilder.RenameTable(
                name: "ArticleConformities",
                newName: "ArticleConformity");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleConformities_ConformityId",
                table: "ArticleConformity",
                newName: "IX_ArticleConformity_ConformityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleConformity",
                table: "ArticleConformity",
                columns: new[] { "ArticleId", "ConformityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleConformity_Articles_ArticleId",
                table: "ArticleConformity",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleConformity_Conformities_ConformityId",
                table: "ArticleConformity",
                column: "ConformityId",
                principalTable: "Conformities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ConformityCheck.Data.Migrations
{
    public partial class ChangeInDbSetsAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleProduct_Articles_ArticleId",
                table: "ArticleProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleProduct_Products_ProductId",
                table: "ArticleProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleSubstance_Articles_ArticleId",
                table: "ArticleSubstance");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleSubstance_Substances_SubstanceId",
                table: "ArticleSubstance");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConformity_Conformities_ConformityId",
                table: "ProductConformity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConformity_Products_ProductId",
                table: "ProductConformity");

            migrationBuilder.DropForeignKey(
                name: "FK_SubstanceRegulationList_RegulationLists_RegulationListId",
                table: "SubstanceRegulationList");

            migrationBuilder.DropForeignKey(
                name: "FK_SubstanceRegulationList_Substances_SubstanceId",
                table: "SubstanceRegulationList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubstanceRegulationList",
                table: "SubstanceRegulationList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductConformity",
                table: "ProductConformity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleSubstance",
                table: "ArticleSubstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleProduct",
                table: "ArticleProduct");

            migrationBuilder.RenameTable(
                name: "SubstanceRegulationList",
                newName: "SubstanceRegulationLists");

            migrationBuilder.RenameTable(
                name: "ProductConformity",
                newName: "ProductConformities");

            migrationBuilder.RenameTable(
                name: "ArticleSubstance",
                newName: "ArticleSubstances");

            migrationBuilder.RenameTable(
                name: "ArticleProduct",
                newName: "ArticleProducts");

            migrationBuilder.RenameIndex(
                name: "IX_SubstanceRegulationList_SubstanceId",
                table: "SubstanceRegulationLists",
                newName: "IX_SubstanceRegulationLists_SubstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductConformity_ConformityId",
                table: "ProductConformities",
                newName: "IX_ProductConformities_ConformityId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleSubstance_SubstanceId",
                table: "ArticleSubstances",
                newName: "IX_ArticleSubstances_SubstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleProduct_ProductId",
                table: "ArticleProducts",
                newName: "IX_ArticleProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubstanceRegulationLists",
                table: "SubstanceRegulationLists",
                columns: new[] { "RegulationListId", "SubstanceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductConformities",
                table: "ProductConformities",
                columns: new[] { "ProductId", "ConformityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleSubstances",
                table: "ArticleSubstances",
                columns: new[] { "ArticleId", "SubstanceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleProducts",
                table: "ArticleProducts",
                columns: new[] { "ArticleId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleProducts_Articles_ArticleId",
                table: "ArticleProducts",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleProducts_Products_ProductId",
                table: "ArticleProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleSubstances_Articles_ArticleId",
                table: "ArticleSubstances",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleSubstances_Substances_SubstanceId",
                table: "ArticleSubstances",
                column: "SubstanceId",
                principalTable: "Substances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConformities_Conformities_ConformityId",
                table: "ProductConformities",
                column: "ConformityId",
                principalTable: "Conformities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConformities_Products_ProductId",
                table: "ProductConformities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubstanceRegulationLists_RegulationLists_RegulationListId",
                table: "SubstanceRegulationLists",
                column: "RegulationListId",
                principalTable: "RegulationLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubstanceRegulationLists_Substances_SubstanceId",
                table: "SubstanceRegulationLists",
                column: "SubstanceId",
                principalTable: "Substances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleProducts_Articles_ArticleId",
                table: "ArticleProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleProducts_Products_ProductId",
                table: "ArticleProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleSubstances_Articles_ArticleId",
                table: "ArticleSubstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleSubstances_Substances_SubstanceId",
                table: "ArticleSubstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConformities_Conformities_ConformityId",
                table: "ProductConformities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductConformities_Products_ProductId",
                table: "ProductConformities");

            migrationBuilder.DropForeignKey(
                name: "FK_SubstanceRegulationLists_RegulationLists_RegulationListId",
                table: "SubstanceRegulationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_SubstanceRegulationLists_Substances_SubstanceId",
                table: "SubstanceRegulationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubstanceRegulationLists",
                table: "SubstanceRegulationLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductConformities",
                table: "ProductConformities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleSubstances",
                table: "ArticleSubstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleProducts",
                table: "ArticleProducts");

            migrationBuilder.RenameTable(
                name: "SubstanceRegulationLists",
                newName: "SubstanceRegulationList");

            migrationBuilder.RenameTable(
                name: "ProductConformities",
                newName: "ProductConformity");

            migrationBuilder.RenameTable(
                name: "ArticleSubstances",
                newName: "ArticleSubstance");

            migrationBuilder.RenameTable(
                name: "ArticleProducts",
                newName: "ArticleProduct");

            migrationBuilder.RenameIndex(
                name: "IX_SubstanceRegulationLists_SubstanceId",
                table: "SubstanceRegulationList",
                newName: "IX_SubstanceRegulationList_SubstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductConformities_ConformityId",
                table: "ProductConformity",
                newName: "IX_ProductConformity_ConformityId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleSubstances_SubstanceId",
                table: "ArticleSubstance",
                newName: "IX_ArticleSubstance_SubstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleProducts_ProductId",
                table: "ArticleProduct",
                newName: "IX_ArticleProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubstanceRegulationList",
                table: "SubstanceRegulationList",
                columns: new[] { "RegulationListId", "SubstanceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductConformity",
                table: "ProductConformity",
                columns: new[] { "ProductId", "ConformityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleSubstance",
                table: "ArticleSubstance",
                columns: new[] { "ArticleId", "SubstanceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleProduct",
                table: "ArticleProduct",
                columns: new[] { "ArticleId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleProduct_Articles_ArticleId",
                table: "ArticleProduct",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleProduct_Products_ProductId",
                table: "ArticleProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleSubstance_Articles_ArticleId",
                table: "ArticleSubstance",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleSubstance_Substances_SubstanceId",
                table: "ArticleSubstance",
                column: "SubstanceId",
                principalTable: "Substances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConformity_Conformities_ConformityId",
                table: "ProductConformity",
                column: "ConformityId",
                principalTable: "Conformities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductConformity_Products_ProductId",
                table: "ProductConformity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubstanceRegulationList_RegulationLists_RegulationListId",
                table: "SubstanceRegulationList",
                column: "RegulationListId",
                principalTable: "RegulationLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubstanceRegulationList_Substances_SubstanceId",
                table: "SubstanceRegulationList",
                column: "SubstanceId",
                principalTable: "Substances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

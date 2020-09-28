using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConformityCheck.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConformityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConformityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegulationLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Source = table.Column<string>(nullable: false),
                    SourceURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulationLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Substances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CASNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    ContactPersonFirstName = table.Column<string>(maxLength: 20, nullable: true),
                    ContactPersonLastName = table.Column<string>(maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleProduct",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleProduct", x => new { x.ArticleId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ArticleProduct_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleSubstance",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    SubstanceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleSubstance", x => new { x.ArticleId, x.SubstanceId });
                    table.ForeignKey(
                        name: "FK_ArticleSubstance_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleSubstance_Substances_SubstanceId",
                        column: x => x.SubstanceId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubstanceRegulationList",
                columns: table => new
                {
                    SubstanceId = table.Column<int>(nullable: false),
                    RegulationListId = table.Column<int>(nullable: false),
                    Restriction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstanceRegulationList", x => new { x.RegulationListId, x.SubstanceId });
                    table.ForeignKey(
                        name: "FK_SubstanceRegulationList_RegulationLists_RegulationListId",
                        column: x => x.RegulationListId,
                        principalTable: "RegulationLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubstanceRegulationList_Substances_SubstanceId",
                        column: x => x.SubstanceId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleSuppliers",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleSuppliers", x => new { x.ArticleId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ArticleSuppliers_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conformities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConformityTypeId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    ConformationAcceptanceDate = table.Column<DateTime>(nullable: true),
                    IsAccepted = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conformities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conformities_ConformityTypes_ConformityTypeId",
                        column: x => x.ConformityTypeId,
                        principalTable: "ConformityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conformities_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleConformity",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    ConformityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleConformity", x => new { x.ArticleId, x.ConformityId });
                    table.ForeignKey(
                        name: "FK_ArticleConformity_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleConformity_Conformities_ConformityId",
                        column: x => x.ConformityId,
                        principalTable: "Conformities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductConformity",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ConformityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductConformity", x => new { x.ProductId, x.ConformityId });
                    table.ForeignKey(
                        name: "FK_ProductConformity_Conformities_ConformityId",
                        column: x => x.ConformityId,
                        principalTable: "Conformities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductConformity_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleConformity_ConformityId",
                table: "ArticleConformity",
                column: "ConformityId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleProduct_ProductId",
                table: "ArticleProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Number",
                table: "Articles",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleSubstance_SubstanceId",
                table: "ArticleSubstance",
                column: "SubstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleSuppliers_SupplierId",
                table: "ArticleSuppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Conformities_ConformityTypeId",
                table: "Conformities",
                column: "ConformityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Conformities_SupplierId",
                table: "Conformities",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ConformityTypes_Description",
                table: "ConformityTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductConformity_ConformityId",
                table: "ProductConformity",
                column: "ConformityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Number",
                table: "Products",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegulationLists_Description",
                table: "RegulationLists",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubstanceRegulationList_SubstanceId",
                table: "SubstanceRegulationList",
                column: "SubstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Substances_CASNumber",
                table: "Substances",
                column: "CASNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleConformity");

            migrationBuilder.DropTable(
                name: "ArticleProduct");

            migrationBuilder.DropTable(
                name: "ArticleSubstance");

            migrationBuilder.DropTable(
                name: "ArticleSuppliers");

            migrationBuilder.DropTable(
                name: "ProductConformity");

            migrationBuilder.DropTable(
                name: "SubstanceRegulationList");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Conformities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RegulationLists");

            migrationBuilder.DropTable(
                name: "Substances");

            migrationBuilder.DropTable(
                name: "ConformityTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Headers",
                columns: table => new
                {
                    HeaderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headers", x => x.HeaderID);
                });

            migrationBuilder.CreateTable(
                name: "ImageFiles",
                columns: table => new
                {
                    ImageFileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageFileTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFiles", x => x.ImageFileID);
                });

            migrationBuilder.CreateTable(
                name: "ProductDiscounts",
                columns: table => new
                {
                    ProductDiscountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDiscountTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDiscountTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDiscountDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscounts", x => x.ProductDiscountID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "ShoeBrands",
                columns: table => new
                {
                    ShoeBrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeBrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeBrands", x => x.ShoeBrandID);
                });

            migrationBuilder.CreateTable(
                name: "ShoeCategories",
                columns: table => new
                {
                    ShoeCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeCategories", x => x.ShoeCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ShoeColors",
                columns: table => new
                {
                    ShoeColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeColorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeColors", x => x.ShoeColorID);
                });

            migrationBuilder.CreateTable(
                name: "ShoePrices",
                columns: table => new
                {
                    ShoePriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoePriceMin = table.Column<int>(type: "int", nullable: false),
                    ShoePriceMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoePrices", x => x.ShoePriceID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductAvailability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeBrandID = table.Column<int>(type: "int", nullable: false),
                    ShoeCategoryID = table.Column<int>(type: "int", nullable: false),
                    ShoeColorID = table.Column<int>(type: "int", nullable: false),
                    ShoePriceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_ShoeBrands_ShoeBrandID",
                        column: x => x.ShoeBrandID,
                        principalTable: "ShoeBrands",
                        principalColumn: "ShoeBrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ShoeCategories_ShoeCategoryID",
                        column: x => x.ShoeCategoryID,
                        principalTable: "ShoeCategories",
                        principalColumn: "ShoeCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ShoeColors_ShoeColorID",
                        column: x => x.ShoeColorID,
                        principalTable: "ShoeColors",
                        principalColumn: "ShoeColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ShoePrices_ShoePriceID",
                        column: x => x.ShoePriceID,
                        principalTable: "ShoePrices",
                        principalColumn: "ShoePriceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoeDiscounts",
                columns: table => new
                {
                    ShoeDiscountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeDiscountModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeDiscountPrice = table.Column<double>(type: "float", nullable: false),
                    ShoeDiscountNewPrice = table.Column<double>(type: "float", nullable: false),
                    ShoeDiscountAvailability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeDiscountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeDiscountImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoeBrandID = table.Column<int>(type: "int", nullable: false),
                    ShoeCategoryID = table.Column<int>(type: "int", nullable: false),
                    ShoeColorID = table.Column<int>(type: "int", nullable: false),
                    ShoePriceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeDiscounts", x => x.ShoeDiscountID);
                    table.ForeignKey(
                        name: "FK_ShoeDiscounts_ShoeBrands_ShoeBrandID",
                        column: x => x.ShoeBrandID,
                        principalTable: "ShoeBrands",
                        principalColumn: "ShoeBrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeDiscounts_ShoeCategories_ShoeCategoryID",
                        column: x => x.ShoeCategoryID,
                        principalTable: "ShoeCategories",
                        principalColumn: "ShoeCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeDiscounts_ShoeColors_ShoeColorID",
                        column: x => x.ShoeColorID,
                        principalTable: "ShoeColors",
                        principalColumn: "ShoeColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeDiscounts_ShoePrices_ShoePriceID",
                        column: x => x.ShoePriceID,
                        principalTable: "ShoePrices",
                        principalColumn: "ShoePriceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoeBrandID",
                table: "Products",
                column: "ShoeBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoeCategoryID",
                table: "Products",
                column: "ShoeCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoeColorID",
                table: "Products",
                column: "ShoeColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoePriceID",
                table: "Products",
                column: "ShoePriceID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDiscounts_ShoeBrandID",
                table: "ShoeDiscounts",
                column: "ShoeBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDiscounts_ShoeCategoryID",
                table: "ShoeDiscounts",
                column: "ShoeCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDiscounts_ShoeColorID",
                table: "ShoeDiscounts",
                column: "ShoeColorID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDiscounts_ShoePriceID",
                table: "ShoeDiscounts",
                column: "ShoePriceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Headers");

            migrationBuilder.DropTable(
                name: "ImageFiles");

            migrationBuilder.DropTable(
                name: "ProductDiscounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ShoeDiscounts");

            migrationBuilder.DropTable(
                name: "ShoeBrands");

            migrationBuilder.DropTable(
                name: "ShoeCategories");

            migrationBuilder.DropTable(
                name: "ShoeColors");

            migrationBuilder.DropTable(
                name: "ShoePrices");
        }
    }
}

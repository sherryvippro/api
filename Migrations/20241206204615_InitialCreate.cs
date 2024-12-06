using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Avatar = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Area",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ManufacturerId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InPrice = table.Column<decimal>(type: "money", nullable: false),
                    SalePrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Product_Manufacturer",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceIn",
                columns: table => new
                {
                    InvoiceInId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TotalPriceIn = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceIn", x => x.InvoiceInId);
                    table.ForeignKey(
                        name: "FK_InvoiceIn_Supplier",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceInDetail",
                columns: table => new
                {
                    InvoiceInId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InQuantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceInDetail", x => new { x.InvoiceInId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_InvoiceInDetail_InvoiceIn",
                        column: x => x.InvoiceInId,
                        principalTable: "InvoiceIn",
                        principalColumn: "InvoiceInId");
                    table.ForeignKey(
                        name: "FK_InvoiceInDetail_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SaleQuantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => new { x.InvoiceId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "AreaId", "AreaName" },
                values: new object[,]
                {
                    { 1, "Quản trị viên" },
                    { 2, "Khách hàng" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { "TL01", "Điện thoại" },
                    { "TL02", "Laptop" },
                    { "TL03", "Phụ kiện" },
                    { "TL04", "Tivi" },
                    { "TL05", "Đồng hồ" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerId", "ManufacturerName" },
                values: new object[,]
                {
                    { "H01", "Apple" },
                    { "H02", "Samsung" },
                    { "H03", "Huawei" },
                    { "H04", "Xiaomi" },
                    { "H05", "Oppo" }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "SupplierId", "SupplierName" },
                values: new object[,]
                {
                    { "NCC01", "Apple" },
                    { "NCC02", "Samsung" },
                    { "NCC03", "Huawei" },
                    { "NCC04", "Xiaomi" },
                    { "NCC05", "Oppo" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceIn",
                columns: new[] { "InvoiceInId", "InDate", "SupplierId", "TotalPriceIn" },
                values: new object[,]
                {
                    { "HDN10000", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(776), "NCC01", 0m },
                    { "HDN10001", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(790), "NCC02", 0m },
                    { "HDN10002", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(791), "NCC02", 0m },
                    { "HDN10003", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(792), "NCC03", 0m },
                    { "HDN10004", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(793), "NCC04", 0m }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Image", "InPrice", "ManufacturerId", "ProductName", "Quantity", "SalePrice" },
                values: new object[,]
                {
                    { "SP10000", "TL01", null, 16000000m, "H01", "iPhone 11 64GB | Chính hãng VN/A", 10, 18000000m },
                    { "SP10001", "TL01", null, 18000000m, "H01", "iPhone 11 128GB | Chính hãng VN/A", 10, 20000000m },
                    { "SP10002", "TL01", null, 19000000m, "H01", "iPhone 11 256GB | Chính hãng VN/A", 10, 21000000m },
                    { "SP10003", "TL01", null, 20000000m, "H01", "iPhone 11 Pro 256GB | Chính hãng VN/A", 10, 23000000m },
                    { "SP10004", "TL01", null, 22000000m, "H01", "iPhone 11 Pro Max 256GB | Chính hãng VN/A", 10, 25000000m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "AreaId", "Avatar", "Email", "FullName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hà Nội", 2, null, "sherryvippro@gmail.com", "Dương Thị Hằng", "123456789", "0346715041" },
                    { 2, "Thái Bình", 2, null, "nvana@gmail.com", "Nguyễn Văn A", "123409584", "0938473021" },
                    { 3, "Hà Nội", 2, null, "duongthia@gmail.com", "Dương Thị A", "123456789", "0346715041" },
                    { 4, "Hà Nội", 2, null, "duongthib@gmail.com", "Dương Thị B", "123456789", "0346715041" },
                    { 5, "Hà Nội", 2, null, "sherrie@gmail.com", "Dương Hằng", "123456789", "0346715041" }
                });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "InvoiceId", "SaleDate", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { "HDB10000", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(822), 0m, 1 },
                    { "HDB10001", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(824), 0m, 2 },
                    { "HDB10002", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(825), 0m, 3 },
                    { "HDB10003", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(826), 0m, 4 },
                    { "HDB10004", new DateTime(2024, 12, 7, 3, 46, 15, 652, DateTimeKind.Local).AddTicks(827), 0m, 5 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceInDetail",
                columns: new[] { "InvoiceInId", "ProductId", "Discount", "InQuantity" },
                values: new object[,]
                {
                    { "HDN10000", "SP10000", "0", 50 },
                    { "HDN10000", "SP10001", "0", 50 },
                    { "HDN10000", "SP10002", "0", 50 },
                    { "HDN10000", "SP10003", "0", 50 },
                    { "HDN10001", "SP10004", "0", 50 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetail",
                columns: new[] { "InvoiceId", "ProductId", "Discount", "Price", "SaleQuantity" },
                values: new object[,]
                {
                    { "HDB10000", "SP10000", "0", 0, 5 },
                    { "HDB10001", "SP10002", "0", 0, 5 },
                    { "HDB10002", "SP10002", "0", 0, 5 },
                    { "HDB10003", "SP10003", "0", 0, 5 },
                    { "HDB10004", "SP10003", "0", 0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserId",
                table: "Invoice",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail",
                table: "InvoiceDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceIn_SupplierId",
                table: "InvoiceIn",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInDetail_ProductId",
                table: "InvoiceInDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerId",
                table: "Product",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AreaId",
                table: "User",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "InvoiceInDetail");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceIn");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}

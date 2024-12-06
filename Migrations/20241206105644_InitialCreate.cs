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
                name: "PhanQuyen",
                columns: table => new
                {
                    IDQuyen = table.Column<int>(type: "int", nullable: false),
                    TenQuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.IDQuyen);
                });

            migrationBuilder.CreateTable(
                name: "tHang",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tTheLoai", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "tNhaCungCap",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenNCC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tNhaCungCap", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "tTheLoai",
                columns: table => new
                {
                    MaTL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenTL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tNhaXuatBan", x => x.MaTL);
                });

            migrationBuilder.CreateTable(
                name: "Nguoidung",
                columns: table => new
                {
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hoten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dienthoai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Matkhau = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDQuyen = table.Column<int>(type: "int", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Anhdaidien = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoidung", x => x.MaNguoiDung);
                    table.ForeignKey(
                        name: "FK_Nguoidung_PhanQuyen",
                        column: x => x.IDQuyen,
                        principalTable: "PhanQuyen",
                        principalColumn: "IDQuyen");
                });

            migrationBuilder.CreateTable(
                name: "tHoaDonNhap",
                columns: table => new
                {
                    SoHDN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime", nullable: false),
                    MaNCC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TongHDN = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tHoaDonNhap", x => x.SoHDN);
                    table.ForeignKey(
                        name: "FK_tHoaDonNhap_tNhaCungCap",
                        column: x => x.MaNCC,
                        principalTable: "tNhaCungCap",
                        principalColumn: "MaNCC");
                });

            migrationBuilder.CreateTable(
                name: "tSP",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaTL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DonGiaNhap = table.Column<decimal>(type: "money", nullable: false),
                    DonGiaBan = table.Column<decimal>(type: "money", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tSach", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_tSP_tHang",
                        column: x => x.MaHang,
                        principalTable: "tHang",
                        principalColumn: "MaHang");
                    table.ForeignKey(
                        name: "FK_tSP_tTheLoai",
                        column: x => x.MaTL,
                        principalTable: "tTheLoai",
                        principalColumn: "MaTL");
                });

            migrationBuilder.CreateTable(
                name: "tHoaDonBan",
                columns: table => new
                {
                    SoHDB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayBan = table.Column<DateTime>(type: "datetime", nullable: false),
                    TongHDB = table.Column<decimal>(type: "money", nullable: false),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tHoaDonBan", x => x.SoHDB);
                    table.ForeignKey(
                        name: "FK_tHoaDonBan_Nguoidung",
                        column: x => x.MaNguoiDung,
                        principalTable: "Nguoidung",
                        principalColumn: "MaNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "tChiTietHDN",
                columns: table => new
                {
                    SoHDN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SLNhap = table.Column<int>(type: "int", nullable: false),
                    KhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tChiTietHDN", x => new { x.SoHDN, x.MaSP });
                    table.ForeignKey(
                        name: "FK_tChiTietHDN_tHoaDonNhap",
                        column: x => x.SoHDN,
                        principalTable: "tHoaDonNhap",
                        principalColumn: "SoHDN");
                    table.ForeignKey(
                        name: "FK_tChiTietHDN_tSP",
                        column: x => x.MaSP,
                        principalTable: "tSP",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateTable(
                name: "tChiTietHDB",
                columns: table => new
                {
                    SoHDB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SLBan = table.Column<int>(type: "int", nullable: false),
                    KhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThanhTien = table.Column<string>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tChiTietHDB", x => new { x.SoHDB, x.MaSP });
                    table.ForeignKey(
                        name: "FK_tChiTietHDB_tHoaDonBan",
                        column: x => x.SoHDB,
                        principalTable: "tHoaDonBan",
                        principalColumn: "SoHDB");
                    table.ForeignKey(
                        name: "FK_tChiTietHDB_tSP",
                        column: x => x.MaSP,
                        principalTable: "tSP",
                        principalColumn: "MaSP");
                });

            migrationBuilder.InsertData(
                table: "PhanQuyen",
                columns: new[] { "IDQuyen", "TenQuyen" },
                values: new object[,]
                {
                    { 1, "Quản trị viên" },
                    { 2, "Khách hàng" }
                });

            migrationBuilder.InsertData(
                table: "tHang",
                columns: new[] { "MaHang", "TenHang" },
                values: new object[,]
                {
                    { "H01", "Apple" },
                    { "H02", "Samsung" },
                    { "H03", "Huawei" },
                    { "H04", "Xiaomi" },
                    { "H05", "Oppo" }
                });

            migrationBuilder.InsertData(
                table: "tNhaCungCap",
                columns: new[] { "MaNCC", "TenNCC" },
                values: new object[,]
                {
                    { "NCC01", "Apple" },
                    { "NCC02", "Samsung" },
                    { "NCC03", "Huawei" },
                    { "NCC04", "Xiaomi" },
                    { "NCC05", "Oppo" }
                });

            migrationBuilder.InsertData(
                table: "tTheLoai",
                columns: new[] { "MaTL", "TenTL" },
                values: new object[,]
                {
                    { "TL01", "Điện thoại" },
                    { "TL02", "Laptop" },
                    { "TL03", "Phụ kiện" },
                    { "TL04", "Tivi" },
                    { "TL05", "Đồng hồ" }
                });

            migrationBuilder.InsertData(
                table: "Nguoidung",
                columns: new[] { "MaNguoiDung", "Anhdaidien", "Diachi", "Dienthoai", "Email", "Hoten", "IDQuyen", "Matkhau" },
                values: new object[,]
                {
                    { 1, null, "Hà Nội", "0346715041", "sherryvippro@gmail.com", "Dương Thị Hằng", 2, "123456789" },
                    { 2, null, "Thái Bình", "0938473021", "nvana@gmail.com", "Nguyễn Văn A", 2, "123409584" },
                    { 3, null, "Hà Nội", "0346715041", "duongthia@gmail.com", "Dương Thị A", 2, "123456789" },
                    { 4, null, "Hà Nội", "0346715041", "duongthib@gmail.com", "Dương Thị B", 2, "123456789" },
                    { 5, null, "Hà Nội", "0346715041", "sherrie@gmail.com", "Dương Hằng", 2, "123456789" }
                });

            migrationBuilder.InsertData(
                table: "tHoaDonNhap",
                columns: new[] { "SoHDN", "MaNCC", "NgayNhap", "TongHDN" },
                values: new object[,]
                {
                    { "HDN10000", "NCC01", new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8376), 0m },
                    { "HDN10001", "NCC02", new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8389), 0m },
                    { "HDN10002", "NCC02", new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8391), 0m },
                    { "HDN10003", "NCC03", new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8393), 0m },
                    { "HDN10004", "NCC04", new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8394), 0m }
                });

            migrationBuilder.InsertData(
                table: "tSP",
                columns: new[] { "MaSP", "Anh", "DonGiaBan", "DonGiaNhap", "MaHang", "MaTL", "SoLuong", "TenSP" },
                values: new object[,]
                {
                    { "SP10000", null, 18000000m, 16000000m, "H01", "TL01", 10, "iPhone 11 64GB | Chính hãng VN/A" },
                    { "SP10001", null, 20000000m, 18000000m, "H01", "TL01", 10, "iPhone 11 128GB | Chính hãng VN/A" },
                    { "SP10002", null, 21000000m, 19000000m, "H01", "TL01", 10, "iPhone 11 256GB | Chính hãng VN/A" },
                    { "SP10003", null, 23000000m, 20000000m, "H01", "TL01", 10, "iPhone 11 Pro 256GB | Chính hãng VN/A" },
                    { "SP10004", null, 25000000m, 22000000m, "H01", "TL01", 10, "iPhone 11 Pro Max 256GB | Chính hãng VN/A" }
                });

            migrationBuilder.InsertData(
                table: "tChiTietHDN",
                columns: new[] { "MaSP", "SoHDN", "KhuyenMai", "SLNhap" },
                values: new object[,]
                {
                    { "SP10000", "HDN10000", "0", 50 },
                    { "SP10001", "HDN10000", "0", 50 },
                    { "SP10002", "HDN10000", "0", 50 },
                    { "SP10003", "HDN10000", "0", 50 },
                    { "SP10004", "HDN10001", "0", 50 }
                });

            migrationBuilder.InsertData(
                table: "tHoaDonBan",
                columns: new[] { "SoHDB", "MaNguoiDung", "NgayBan", "TongHDB" },
                values: new object[,]
                {
                    { "HDB10000", 1, new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8424), 0m },
                    { "HDB10001", 2, new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8426), 0m },
                    { "HDB10002", 3, new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8427), 0m },
                    { "HDB10003", 4, new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8429), 0m },
                    { "HDB10004", 5, new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8430), 0m }
                });

            migrationBuilder.InsertData(
                table: "tChiTietHDB",
                columns: new[] { "MaSP", "SoHDB", "KhuyenMai", "SLBan", "ThanhTien" },
                values: new object[,]
                {
                    { "SP10000", "HDB10000", "0", 5, null },
                    { "SP10002", "HDB10000", "0", 5, null },
                    { "SP10002", "HDB10001", "0", 5, null },
                    { "SP10003", "HDB10001", "0", 5, null },
                    { "SP10003", "HDB10002", "0", 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nguoidung_IDQuyen",
                table: "Nguoidung",
                column: "IDQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_tChiTietHDB",
                table: "tChiTietHDB",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_tChiTietHDN_MaSP",
                table: "tChiTietHDN",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_tHoaDonBan_MaNguoiDung",
                table: "tHoaDonBan",
                column: "MaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_tHoaDonNhap_MaNCC",
                table: "tHoaDonNhap",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_tSP_MaHang",
                table: "tSP",
                column: "MaHang");

            migrationBuilder.CreateIndex(
                name: "IX_tSP_MaTL",
                table: "tSP",
                column: "MaTL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tChiTietHDB");

            migrationBuilder.DropTable(
                name: "tChiTietHDN");

            migrationBuilder.DropTable(
                name: "tHoaDonBan");

            migrationBuilder.DropTable(
                name: "tHoaDonNhap");

            migrationBuilder.DropTable(
                name: "tSP");

            migrationBuilder.DropTable(
                name: "Nguoidung");

            migrationBuilder.DropTable(
                name: "tNhaCungCap");

            migrationBuilder.DropTable(
                name: "tHang");

            migrationBuilder.DropTable(
                name: "tTheLoai");

            migrationBuilder.DropTable(
                name: "PhanQuyen");
        }
    }
}

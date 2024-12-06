using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _api.Migrations
{
    /// <inheritdoc />
    public partial class Update_ND_THOADONBAN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tHoaDonBan_Nguoidung",
                table: "tHoaDonBan");

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10000", "HDB10000" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10002", "HDB10000" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10002", "HDB10001" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10003", "HDB10001" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10003", "HDB10002" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10000",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10001",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10002",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10003",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10004",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10000",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10001",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10002",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10003",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10004",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 21, 45, 17, 838, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.AddForeignKey(
                name: "FK_tHoaDonBan_Nguoidung_MaNguoiDung",
                table: "tHoaDonBan",
                column: "MaNguoiDung",
                principalTable: "Nguoidung",
                principalColumn: "MaNguoiDung",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tHoaDonBan_Nguoidung_MaNguoiDung",
                table: "tHoaDonBan");

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10000", "HDB10000" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10002", "HDB10000" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10002", "HDB10001" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10003", "HDB10001" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tChiTietHDB",
                keyColumns: new[] { "MaSP", "SoHDB" },
                keyValues: new object[] { "SP10003", "HDB10002" },
                column: "ThanhTien",
                value: null);

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10000",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10001",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10002",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10003",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "tHoaDonBan",
                keyColumn: "SoHDB",
                keyValue: "HDB10004",
                column: "NgayBan",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10000",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10001",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10002",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10003",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "tHoaDonNhap",
                keyColumn: "SoHDN",
                keyValue: "HDN10004",
                column: "NgayNhap",
                value: new DateTime(2024, 12, 6, 17, 56, 44, 93, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.AddForeignKey(
                name: "FK_tHoaDonBan_Nguoidung",
                table: "tHoaDonBan",
                column: "MaNguoiDung",
                principalTable: "Nguoidung",
                principalColumn: "MaNguoiDung");
        }
    }
}

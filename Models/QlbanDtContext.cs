using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _api.Models;

public partial class QlbanDtContext : DbContext
{
    public QlbanDtContext()
    {
    }

    public QlbanDtContext(DbContextOptions<QlbanDtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietHdn> TChiTietHdns { get; set; }

    public virtual DbSet<THang> THangs { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<THoaDonNhap> THoaDonNhaps { get; set; }

    public virtual DbSet<TNhaCungCap> TNhaCungCaps { get; set; }

    public virtual DbSet<TSp> TSp { get; set; }

    public virtual DbSet<TTheLoai> TTheLoais { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhanQuyen>().HasData(
            new PhanQuyen
            {
                Idquyen = 1,
                TenQuyen = "Quản trị viên"
            },
            new PhanQuyen
            {
                Idquyen = 2,
                TenQuyen = "Khách hàng"
            }
            );
        modelBuilder.Entity<Nguoidung>().HasData(
            new Nguoidung
            {
                MaNguoiDung = 1,
                Hoten = "Dương Thị Hằng",
                Email = "sherryvippro@gmail.com",
                Dienthoai = "0346715041",
                Matkhau = "123456789",
                Idquyen = 2,
                Diachi = "Hà Nội",
                Anhdaidien = null
            },
            new Nguoidung
            {
                MaNguoiDung = 2,
                Hoten = "Nguyễn Văn A",
                Email = "nvana@gmail.com",
                Dienthoai = "0938473021",
                Matkhau = "123409584",
                Idquyen = 2,
                Diachi = "Thái Bình",
            },
            new Nguoidung
            {
                MaNguoiDung = 3,
                Hoten = "Dương Thị A",
                Email = "duongthia@gmail.com",
                Dienthoai = "0346715041",
                Matkhau = "123456789",
                Idquyen = 2,
                Diachi = "Hà Nội",
            },
            new Nguoidung
            {
                MaNguoiDung = 4,
                Hoten = "Dương Thị B",
                Email = "duongthib@gmail.com",
                Dienthoai = "0346715041",
                Matkhau = "123456789",
                Idquyen = 2,
                Diachi = "Hà Nội",
            },
            new Nguoidung
            {
                MaNguoiDung = 5,
                Hoten = "Dương Hằng",
                Email = "sherrie@gmail.com",
                Dienthoai = "0346715041",
                Matkhau = "123456789",
                Idquyen = 2,
                Diachi = "Hà Nội",
            }
            );
        modelBuilder.Entity<TTheLoai>().HasData(
            new TTheLoai
            {
                MaTl = "TL01",
                TenTl = "Điện thoại"
            },
            new TTheLoai
            {
                MaTl = "TL02",
                TenTl = "Laptop"
            },
            new TTheLoai
            {
                MaTl = "TL03",
                TenTl = "Phụ kiện"
            },
            new TTheLoai
            {
                MaTl = "TL04",
                TenTl = "Tivi"
            },
            new TTheLoai
            {
                MaTl = "TL05",
                TenTl = "Đồng hồ"
            });
        modelBuilder.Entity<TNhaCungCap>().HasData(
            new TNhaCungCap { MaNcc = "NCC01", TenNcc = "Apple" },
            new TNhaCungCap { MaNcc = "NCC02", TenNcc = "Samsung" },
            new TNhaCungCap { MaNcc = "NCC03", TenNcc = "Huawei" },
            new TNhaCungCap { MaNcc = "NCC04", TenNcc = "Xiaomi" },
            new TNhaCungCap { MaNcc = "NCC05", TenNcc = "Oppo" });
        modelBuilder.Entity<THang>().HasData(
            new THang { MaHang = "H01", TenHang = "Apple" },
            new THang { MaHang = "H02", TenHang = "Samsung" },
            new THang { MaHang = "H03", TenHang = "Huawei" },
            new THang { MaHang = "H04", TenHang = "Xiaomi" },
            new THang { MaHang = "H05", TenHang = "Oppo" });
        modelBuilder.Entity<TSp>().HasData(
            new TSp { MaSp = "SP10000", TenSp = "iPhone 11 64GB | Chính hãng VN/A", MaTl = "TL01", MaHang = "H01", DonGiaNhap = 16000000, DonGiaBan = 18000000, SoLuong = 10, Anh = null },
            new TSp { MaSp = "SP10001", TenSp = "iPhone 11 128GB | Chính hãng VN/A", MaTl = "TL01", MaHang = "H01", DonGiaNhap = 18000000, DonGiaBan = 20000000, SoLuong = 10, Anh = null },
            new TSp {MaSp = "SP10002", TenSp = "iPhone 11 256GB | Chính hãng VN/A", MaTl = "TL01", MaHang = "H01", DonGiaNhap = 19000000, DonGiaBan = 21000000, SoLuong = 10, Anh = null },
            new TSp {MaSp = "SP10003", TenSp = "iPhone 11 Pro 256GB | Chính hãng VN/A", MaTl = "TL01", MaHang = "H01", DonGiaNhap = 20000000, DonGiaBan = 23000000, SoLuong = 10, Anh = null },
            new TSp {MaSp = "SP10004", TenSp = "iPhone 11 Pro Max 256GB | Chính hãng VN/A", MaTl = "TL01", MaHang = "H01", DonGiaNhap = 22000000, DonGiaBan = 25000000, SoLuong = 10, Anh = null }
            );
        modelBuilder.Entity<THoaDonNhap>().HasData(
            new THoaDonNhap { SoHdn = "HDN10000", NgayNhap = DateTime.Now, TongHdn = 0, MaNcc = "NCC01" },
            new THoaDonNhap { SoHdn = "HDN10001", NgayNhap = DateTime.Now, TongHdn = 0, MaNcc = "NCC02" },
            new THoaDonNhap { SoHdn = "HDN10002", NgayNhap = DateTime.Now, TongHdn = 0, MaNcc = "NCC02" },
            new THoaDonNhap { SoHdn = "HDN10003", NgayNhap = DateTime.Now, TongHdn = 0, MaNcc = "NCC03" },
            new THoaDonNhap { SoHdn = "HDN10004", NgayNhap = DateTime.Now, TongHdn = 0, MaNcc = "NCC04" }
            );
        modelBuilder.Entity<TChiTietHdn>().HasData(
            new TChiTietHdn { SoHdn = "HDN10000", MaSp = "SP10000", Slnhap = 50, KhuyenMai = "0" },
            new TChiTietHdn { SoHdn = "HDN10000", MaSp = "SP10001", Slnhap = 50, KhuyenMai = "0" },
            new TChiTietHdn { SoHdn = "HDN10000", MaSp = "SP10002", Slnhap = 50, KhuyenMai = "0" },
            new TChiTietHdn { SoHdn = "HDN10000", MaSp = "SP10003", Slnhap = 50, KhuyenMai = "0" },
            new TChiTietHdn { SoHdn = "HDN10001", MaSp = "SP10004", Slnhap = 50, KhuyenMai = "0" }
            );
        modelBuilder.Entity<THoaDonBan>().HasData(
            new THoaDonBan { SoHdb = "HDB10000", MaNguoiDung = 1, NgayBan = DateTime.Now, TongHdb = 0 },
            new THoaDonBan { SoHdb = "HDB10001", MaNguoiDung = 2, NgayBan = DateTime.Now, TongHdb = 0 },
            new THoaDonBan { SoHdb = "HDB10002", MaNguoiDung = 3, NgayBan = DateTime.Now, TongHdb = 0 },
            new THoaDonBan { SoHdb = "HDB10003", MaNguoiDung = 4, NgayBan = DateTime.Now, TongHdb = 0 },
            new THoaDonBan { SoHdb = "HDB10004", MaNguoiDung = 5, NgayBan = DateTime.Now, TongHdb = 0 }
            );
        modelBuilder.Entity<TChiTietHdb>().HasData(
            new TChiTietHdb { SoHdb = "HDB10000", MaSp = "SP10000", Slban = 5, KhuyenMai = "0" },
            new TChiTietHdb { SoHdb = "HDB10000", MaSp = "SP10002", Slban = 5, KhuyenMai = "0" },
            new TChiTietHdb { SoHdb = "HDB10001", MaSp = "SP10002", Slban = 5, KhuyenMai = "0" },
            new TChiTietHdb { SoHdb = "HDB10001", MaSp = "SP10003", Slban = 5, KhuyenMai = "0" },
            new TChiTietHdb { SoHdb = "HDB10002", MaSp = "SP10003", Slban = 5, KhuyenMai = "0" }
            );

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK_Nguoidung");

            entity.ToTable("Nguoidung");
            entity.Property(n => n.MaNguoiDung).ValueGeneratedOnAdd();
            entity.Property(e => e.Anhdaidien)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Diachi).HasMaxLength(100);
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Hoten).HasMaxLength(50);
            entity.Property(e => e.Idquyen).HasColumnName("IDQuyen");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdquyenNavigation).WithMany(p => p.Nguoidungs)
                .HasForeignKey(d => d.Idquyen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nguoidung_PhanQuyen");
            entity.HasMany(n => n.THoaDonBans).WithOne(t => t.MaNguoiDungNavigation).HasForeignKey(x => x.MaNguoiDung).IsRequired();
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.Idquyen);

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.Idquyen)
                .ValueGeneratedNever()
                .HasColumnName("IDQuyen");
            entity.Property(e => e.TenQuyen).HasMaxLength(50);
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.SoHdb, e.MaSp });

            entity.ToTable("tChiTietHDB");

            entity.HasIndex(e => e.MaSp, "IX_tChiTietHDB");

            entity.Property(e => e.SoHdb)
                .HasMaxLength(10)
                .HasColumnName("SoHDB");
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.KhuyenMai).HasMaxLength(100);
            entity.Property(e => e.Slban).HasColumnName("SLBan");
            entity.Property(e => e.ThanhTien).HasColumnType("integer");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tSP");

            entity.HasOne(d => d.SoHdbNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.SoHdb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tHoaDonBan");
        });

        modelBuilder.Entity<TChiTietHdn>(entity =>
        {
            entity.HasKey(e => new { e.SoHdn, e.MaSp });

            entity.ToTable("tChiTietHDN");

            entity.Property(e => e.SoHdn)
                .HasMaxLength(10)
                .HasColumnName("SoHDN");
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.KhuyenMai).HasMaxLength(100);
            entity.Property(e => e.Slnhap).HasColumnName("SLNhap");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietHdns)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDN_tSP");

            entity.HasOne(d => d.SoHdnNavigation).WithMany(p => p.TChiTietHdns)
                .HasForeignKey(d => d.SoHdn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDN_tHoaDonNhap");
        });

        modelBuilder.Entity<THang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK_tTheLoai");

            entity.ToTable("tHang");

            entity.Property(e => e.MaHang).HasMaxLength(10);
            entity.Property(e => e.TenHang).HasMaxLength(100);
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.SoHdb);

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.SoHdb)
                .HasMaxLength(10)
                .HasColumnName("SoHDB");
            entity.Property(e => e.NgayBan).HasColumnType("datetime");
            entity.Property(e => e.TongHdb)
                .HasColumnType("money")
                .HasColumnName("TongHDB");

            entity.HasMany(t => t.TChiTietHdbs).WithOne(hdb => hdb.SoHdbNavigation).HasForeignKey(x => x.SoHdb).IsRequired();
        });

        modelBuilder.Entity<THoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.SoHdn);

            entity.ToTable("tHoaDonNhap");

            entity.Property(e => e.SoHdn)
                .HasMaxLength(10)
                .HasColumnName("SoHDN");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(10)
                .HasColumnName("MaNCC");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
            entity.Property(e => e.TongHdn)
                .HasColumnType("money")
                .HasColumnName("TongHDN");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.THoaDonNhaps)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tHoaDonNhap_tNhaCungCap");
        });

        modelBuilder.Entity<TNhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc);

            entity.ToTable("tNhaCungCap");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(10)
                .HasColumnName("MaNCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(200)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<TSp>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK_tSach");

            entity.ToTable("tSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.Anh).HasMaxLength(100);
            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.DonGiaNhap).HasColumnType("money");
            entity.Property(e => e.MaHang).HasMaxLength(10);
            entity.Property(e => e.MaTl)
                .HasMaxLength(10)
                .HasColumnName("MaTL");
            entity.Property(e => e.TenSp)
                .HasMaxLength(200)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.TSp)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tSP_tHang");

            entity.HasOne(d => d.MaTlNavigation).WithMany(p => p.TSp)
                .HasForeignKey(d => d.MaTl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tSP_tTheLoai");
        });

        modelBuilder.Entity<TTheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTl).HasName("PK_tNhaXuatBan");

            entity.ToTable("tTheLoai");

            entity.Property(e => e.MaTl)
                .HasMaxLength(10)
                .HasColumnName("MaTL");
            entity.Property(e => e.TenTl)
                .HasMaxLength(100)
                .HasColumnName("TenTL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

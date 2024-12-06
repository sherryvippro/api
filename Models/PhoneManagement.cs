using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _api.Models;

public partial class PhoneManagement : DbContext
{
    public PhoneManagement()
    {
    }

    public PhoneManagement(DbContextOptions<PhoneManagement> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceInDetail> InvoiceInDetails { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceIn> InvoiceIns { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<Category> Categorys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>().HasData(
            new Area
            {
                AreaId = 1,
                AreaName = "Quản trị viên"
            },
            new Area
            {
                AreaId = 2,
                AreaName = "Khách hàng"
            }
            );
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                FullName = "Dương Thị Hằng",
                Email = "sherryvippro@gmail.com",
                PhoneNumber = "0346715041",
                Password = "123456789",
                AreaId = 2,
                Address = "Hà Nội",
                Avatar = null
            },
            new User
            {
                UserId = 2,
                FullName = "Nguyễn Văn A",
                Email = "nvana@gmail.com",
                PhoneNumber = "0938473021",
                Password = "123409584",
                AreaId = 2,
                Address = "Thái Bình",
            },
            new User
            {
                UserId = 3,
                FullName = "Dương Thị A",
                Email = "duongthia@gmail.com",
                PhoneNumber = "0346715041",
                Password = "123456789",
                AreaId = 2,
                Address = "Hà Nội",
            },
            new User
            {
                UserId = 4,
                FullName = "Dương Thị B",
                Email = "duongthib@gmail.com",
                PhoneNumber = "0346715041",
                Password = "123456789",
                AreaId = 2,
                Address = "Hà Nội",
            },
            new User
            {
                UserId = 5,
                FullName = "Dương Hằng",
                Email = "sherrie@gmail.com",
                PhoneNumber = "0346715041",
                Password = "123456789",
                AreaId = 2,
                Address = "Hà Nội",
            }
            );
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = "TL01",
                CategoryName = "Điện thoại"
            },
            new Category
            {
                CategoryId = "TL02",
                CategoryName = "Laptop"
            },
            new Category
            {
                CategoryId = "TL03",
                CategoryName = "Phụ kiện"
            },
            new Category
            {
                CategoryId = "TL04",
                CategoryName = "Tivi"
            },
            new Category
            {
                CategoryId = "TL05",
                CategoryName = "Đồng hồ"
            });
        modelBuilder.Entity<Supplier>().HasData(
            new Supplier { SupplierId = "NCC01", SupplierName = "Apple" },
            new Supplier { SupplierId = "NCC02", SupplierName = "Samsung" },
            new Supplier { SupplierId = "NCC03", SupplierName = "Huawei" },
            new Supplier { SupplierId = "NCC04", SupplierName = "Xiaomi" },
            new Supplier { SupplierId = "NCC05", SupplierName = "Oppo" });
        modelBuilder.Entity<Manufacturer>().HasData(
            new Manufacturer { ManufacturerId = "H01", ManufacturerName = "Apple" },
            new Manufacturer { ManufacturerId = "H02", ManufacturerName = "Samsung" },
            new Manufacturer { ManufacturerId = "H03", ManufacturerName = "Huawei" },
            new Manufacturer { ManufacturerId = "H04", ManufacturerName = "Xiaomi" },
            new Manufacturer { ManufacturerId = "H05", ManufacturerName = "Oppo" });
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "SP10000", ProductName = "iPhone 11 64GB | Chính hãng VN/A", CategoryId = "TL01", ManufacturerId = "H01", InPrice = 16000000, SalePrice = 18000000, Quantity = 10, Image = null },
            new Product { ProductId = "SP10001", ProductName = "iPhone 11 128GB | Chính hãng VN/A", CategoryId = "TL01", ManufacturerId = "H01", InPrice = 18000000, SalePrice = 20000000, Quantity = 10, Image = null },
            new Product {ProductId = "SP10002", ProductName = "iPhone 11 256GB | Chính hãng VN/A", CategoryId = "TL01", ManufacturerId = "H01", InPrice = 19000000, SalePrice = 21000000, Quantity = 10, Image = null },
            new Product {ProductId = "SP10003", ProductName = "iPhone 11 Pro 256GB | Chính hãng VN/A", CategoryId = "TL01", ManufacturerId = "H01", InPrice = 20000000, SalePrice = 23000000, Quantity = 10, Image = null },
            new Product {ProductId = "SP10004", ProductName = "iPhone 11 Pro Max 256GB | Chính hãng VN/A", CategoryId = "TL01", ManufacturerId = "H01", InPrice = 22000000, SalePrice = 25000000, Quantity = 10, Image = null }
            );
        modelBuilder.Entity<InvoiceIn>().HasData(
            new InvoiceIn { InvoiceInId = "HDN10000", InDate = DateTime.Now, TotalPriceIn = 0, SupplierId = "NCC01" },
            new InvoiceIn { InvoiceInId = "HDN10001", InDate = DateTime.Now, TotalPriceIn = 0, SupplierId = "NCC02" },
            new InvoiceIn { InvoiceInId = "HDN10002", InDate = DateTime.Now, TotalPriceIn = 0, SupplierId = "NCC02" },
            new InvoiceIn { InvoiceInId = "HDN10003", InDate = DateTime.Now, TotalPriceIn = 0, SupplierId = "NCC03" },
            new InvoiceIn { InvoiceInId = "HDN10004", InDate = DateTime.Now, TotalPriceIn = 0, SupplierId = "NCC04" }
            );
        modelBuilder.Entity<InvoiceInDetail>().HasData(
            new InvoiceInDetail { InvoiceInId = "HDN10000", ProductId = "SP10000", InQuantity = 50, Discount = "0" },
            new InvoiceInDetail { InvoiceInId = "HDN10000", ProductId = "SP10001", InQuantity = 50, Discount = "0" },
            new InvoiceInDetail { InvoiceInId = "HDN10000", ProductId = "SP10002", InQuantity = 50, Discount = "0" },
            new InvoiceInDetail { InvoiceInId = "HDN10000", ProductId = "SP10003", InQuantity = 50, Discount = "0" },
            new InvoiceInDetail { InvoiceInId = "HDN10001", ProductId = "SP10004", InQuantity = 50, Discount = "0" }
            );
        modelBuilder.Entity<Invoice>().HasData(
            new Invoice { InvoiceId = "HDB10000", UserId = 1, SaleDate = DateTime.Now, TotalPrice = 90000000 },
            new Invoice { InvoiceId = "HDB10001", UserId = 2, SaleDate = DateTime.Now, TotalPrice = 105000000 },
            new Invoice { InvoiceId = "HDB10002", UserId = 3, SaleDate = DateTime.Now, TotalPrice = 105000000            },
            new Invoice { InvoiceId = "HDB10003", UserId = 4, SaleDate = DateTime.Now, TotalPrice = 115000000 },
            new Invoice { InvoiceId = "HDB10004", UserId = 5, SaleDate = DateTime.Now, TotalPrice = 115000000 }
            );
        modelBuilder.Entity<InvoiceDetail>().HasData(
            new InvoiceDetail { InvoiceId = "HDB10000", ProductId = "SP10000", SaleQuantity = 5, Discount = "0", Price = 90000000 },
            new InvoiceDetail { InvoiceId = "HDB10001", ProductId = "SP10002", SaleQuantity = 5, Discount = "0", Price = 105000000 },
            new InvoiceDetail { InvoiceId = "HDB10002", ProductId = "SP10002", SaleQuantity = 5, Discount = "0", Price = 105000000 },
            new InvoiceDetail { InvoiceId = "HDB10003", ProductId = "SP10003", SaleQuantity = 5, Discount = "0" , Price = 115000000 },
            new InvoiceDetail { InvoiceId = "HDB10004", ProductId = "SP10003", SaleQuantity = 5, Discount = "0" , Price = 115000000 }
            );

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User");

            entity.ToTable("User");
            entity.Property(n => n.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.Avatar)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.AreaId).HasColumnName("AreaId");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.AreaIdNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Area");
            entity.HasMany(n => n.Invoices).WithOne(t => t.UserIdNavigation).HasForeignKey(x => x.UserId).IsRequired();
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId);

            entity.ToTable("Area");

            entity.Property(e => e.AreaId)
                .ValueGeneratedNever()
                .HasColumnName("AreaId");
            entity.Property(e => e.AreaName).HasMaxLength(50);
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ProductId });

            entity.ToTable("InvoiceDetail");

            entity.HasIndex(e => e.ProductId, "IX_InvoiceDetail");

            entity.Property(e => e.InvoiceId)
                .HasMaxLength(10)
                .HasColumnName("InvoiceId");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .HasColumnName("ProductId");
            entity.Property(e => e.Discount).HasMaxLength(100);
            entity.Property(e => e.SaleQuantity).HasColumnName("SaleQuantity");
            entity.Property(e => e.Price).HasColumnType("integer");

            entity.HasOne(d => d.ProductIdNavigation).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetail_Product");

            entity.HasOne(d => d.InvoiceIdNavigation).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetail_Invoice");
        });

        modelBuilder.Entity<InvoiceInDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceInId, e.ProductId });

            entity.ToTable("InvoiceInDetail");

            entity.Property(e => e.InvoiceInId)
                .HasMaxLength(10)
                .HasColumnName("InvoiceInId");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .HasColumnName("ProductId");
            entity.Property(e => e.Discount).HasMaxLength(100);
            entity.Property(e => e.InQuantity).HasColumnName("InQuantity");

            entity.HasOne(d => d.ProductIdNavigation).WithMany(p => p.InvoiceInDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceInDetail_Product");

            entity.HasOne(d => d.InvoiceInIdNavigation).WithMany(p => p.InvoiceInDetails)
                .HasForeignKey(d => d.InvoiceInId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceInDetail_InvoiceIn");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK_Manufacturer");

            entity.ToTable("Manufacturer");

            entity.Property(e => e.ManufacturerId).HasMaxLength(10);
            entity.Property(e => e.ManufacturerName).HasMaxLength(100);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId);

            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceId)
                .HasMaxLength(10)
                .HasColumnName("InvoiceId");
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("TotalPrice");
            entity.HasMany(t => t.InvoiceDetails).WithOne(hdb => hdb.InvoiceIdNavigation).HasForeignKey(x => x.InvoiceId).IsRequired();
        });

        modelBuilder.Entity<InvoiceIn>(entity =>
        {
            entity.HasKey(e => e.InvoiceInId);

            entity.ToTable("InvoiceIn");

            entity.Property(e => e.InvoiceInId)
                .HasMaxLength(10)
                .HasColumnName("InvoiceInId");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(10)
                .HasColumnName("SupplierId");
            entity.Property(e => e.InDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPriceIn)
                .HasColumnType("money")
                .HasColumnName("TotalPriceIn");

            entity.HasOne(d => d.SupplierIdNavigation).WithMany(p => p.InvoiceIns)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceIn_Supplier");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId);

            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId)
                .HasMaxLength(10)
                .HasColumnName("SupplierId");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(200)
                .HasColumnName("SupplierName");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .HasColumnName("ProductId");
            entity.Property(e => e.Image).HasMaxLength(100);
            entity.Property(e => e.SalePrice).HasColumnType("money");
            entity.Property(e => e.InPrice).HasColumnType("money");
            entity.Property(e => e.ManufacturerId).HasMaxLength(10);
            entity.Property(e => e.CategoryId)
                .HasMaxLength(10)
                .HasColumnName("CategoryId");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .HasColumnName("ProductName");

            entity.HasOne(d => d.ManufacturerIdNavigation).WithMany(p => p.Product)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Manufacturer");

            entity.HasOne(d => d.CategoryIdNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Category");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(10)
                .HasColumnName("CategoryId");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("CategoryName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

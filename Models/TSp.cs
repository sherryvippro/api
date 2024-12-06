using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class TSp
{
    public string MaSp { get; set; } = null!;

    public string TenSp { get; set; } = null!;

    public string MaTl { get; set; } = null!;

    public string MaHang { get; set; } = null!;

    public decimal DonGiaNhap { get; set; }

    public decimal DonGiaBan { get; set; }

    public int SoLuong { get; set; }

    public string? Anh { get; set; }

    public virtual THang? MaHangNavigation { get; set; } = null!;

    public virtual TTheLoai? MaTlNavigation { get; set; } = null!;

    public virtual ICollection<TChiTietHdb> TChiTietHdbs { get; set; } = new List<TChiTietHdb>();

    public virtual ICollection<TChiTietHdn> TChiTietHdns { get; set; } = new List<TChiTietHdn>();
}

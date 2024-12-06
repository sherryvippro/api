using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class THoaDonNhap
{
    public string SoHdn { get; set; } = null!;

    public DateTime NgayNhap { get; set; }

    public string MaNcc { get; set; } = null!;

    public decimal TongHdn { get; set; }

    public virtual TNhaCungCap MaNccNavigation { get; set; } = null!;

    public virtual ICollection<TChiTietHdn> TChiTietHdns { get; set; } = new List<TChiTietHdn>();
}

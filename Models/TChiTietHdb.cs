using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace _api.Models;

public partial class TChiTietHdb
{
    public string SoHdb { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public int Slban { get; set; }

    public string? KhuyenMai { get; set; }
    public int? ThanhTien { get; set; }

    public virtual TSp? MaSpNavigation { get; set; } = null!;

    public virtual THoaDonBan? SoHdbNavigation { get; set; } = null!;
}

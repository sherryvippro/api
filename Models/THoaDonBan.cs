using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace _api.Models;

public partial class THoaDonBan
{
    public string SoHdb { get; set; } = null!;

    public DateTime NgayBan { get; set; }

    public decimal TongHdb { get; set; }

    public int MaNguoiDung { get; set; }

    public virtual Nguoidung? MaNguoiDungNavigation { get; set; } = null!;

    public ICollection<TChiTietHdb> TChiTietHdbs { get; set; } = new List<TChiTietHdb>();
}

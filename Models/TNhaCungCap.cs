using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class TNhaCungCap
{
    public string MaNcc { get; set; } = null!;

    public string TenNcc { get; set; } = null!;

    public virtual ICollection<THoaDonNhap> THoaDonNhaps { get; set; } = new List<THoaDonNhap>();
}

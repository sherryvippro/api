using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class Nguoidung
{
    public int MaNguoiDung { get; set; }

    public string Hoten { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Dienthoai { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public int Idquyen { get; set; }

    public string? Diachi { get; set; }

    public string? Anhdaidien { get; set; }

    public virtual PhanQuyen IdquyenNavigation { get; set; } = null!;

    public virtual ICollection<THoaDonBan> THoaDonBans { get; set; } = new List<THoaDonBan>();
}

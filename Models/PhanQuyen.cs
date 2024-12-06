using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class PhanQuyen
{
    public int Idquyen { get; set; }

    public string TenQuyen { get; set; } = null!;

    public virtual ICollection<Nguoidung> Nguoidungs { get; set; } = new List<Nguoidung>();
}

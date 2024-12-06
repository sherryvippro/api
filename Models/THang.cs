using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class THang
{
    public string MaHang { get; set; } = null!;

    public string TenHang { get; set; } = null!;

    public virtual ICollection<TSp> TSp { get; set; } = new List<TSp>();
}

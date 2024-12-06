using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class TTheLoai
{
    public string MaTl { get; set; } = null!;

    public string TenTl { get; set; } = null!;

    public virtual ICollection<TSp> TSp { get; set; } = new List<TSp>();
}

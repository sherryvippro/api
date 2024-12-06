using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

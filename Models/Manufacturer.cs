using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class Manufacturer
{
    public string ManufacturerId { get; set; } = null!;

    public string ManufacturerName { get; set; } = null!;

    public virtual ICollection<Product> Product { get; set; } = new List<Product>();
}

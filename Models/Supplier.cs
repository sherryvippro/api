using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class Supplier
{
    public string SupplierId { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public virtual ICollection<InvoiceIn> InvoiceIns { get; set; } = new List<InvoiceIn>();
}

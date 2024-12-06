using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class InvoiceIn
{
    public string InvoiceInId { get; set; } = null!;

    public DateTime InDate { get; set; }

    public string SupplierId { get; set; } = null!;

    public decimal TotalPriceIn { get; set; }

    public virtual Supplier SupplierIdNavigation { get; set; } = null!;

    public virtual ICollection<InvoiceInDetail> InvoiceInDetails { get; set; } = new List<InvoiceInDetail>();
}

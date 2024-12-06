using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class InvoiceInDetail
{
    public string InvoiceInId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int InQuantity { get; set; }

    public string? Discount { get; set; }

    public virtual Product ProductIdNavigation { get; set; } = null!;

    public virtual InvoiceIn InvoiceInIdNavigation { get; set; } = null!;
}

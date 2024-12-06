using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace _api.Models;

public partial class InvoiceDetail
{
    public string InvoiceId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int SaleQuantity { get; set; }

    public string? Discount { get; set; }
    public int? Price { get; set; }

    public virtual Product? ProductIdNavigation { get; set; } = null!;

    public virtual Invoice? InvoiceIdNavigation { get; set; } = null!;
}

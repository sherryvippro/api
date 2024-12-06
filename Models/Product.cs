using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string CategoryId { get; set; } = null!;

    public string ManufacturerId { get; set; } = null!;

    public decimal InPrice { get; set; }

    public decimal SalePrice { get; set; }

    public int Quantity { get; set; }

    public string? Image { get; set; }

    public virtual Manufacturer? ManufacturerIdNavigation { get; set; } = null!;

    public virtual Category? CategoryIdNavigation { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<InvoiceInDetail> InvoiceInDetails { get; set; } = new List<InvoiceInDetail>();
}

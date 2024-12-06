using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace _api.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public decimal TotalPrice { get; set; }

    public int UserId { get; set; }

    public virtual User? UserIdNavigation { get; set; } = null!;

    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}

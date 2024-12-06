﻿
namespace _api.InputModels
{
    public class InputInvoiceDetail
    {
        public string InvoiceId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public int SaleQuantity { get; set; }
        public string? Discount { get; set; }
        public int? Price { get; set; }
    }
}

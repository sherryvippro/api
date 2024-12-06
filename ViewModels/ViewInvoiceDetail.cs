using _api.Models;

namespace _api.ViewModel
{
    public class ViewInvoiceDetail
    {
        public string InvoiceId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public int SaleQuantity { get; set; }

        public string? Discount { get; set; }
        public int? Price { get; set; }

        public string? ProductName { get; set; }
    }
}
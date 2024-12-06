using _api.Models;

namespace _api.ViewModel
{
    public class ViewInvoice
    {
        public string InvoiceId { get; set; } = null!;

        public string? SaleDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string? FullName { get; set; }

        public ICollection<ViewInvoiceDetail> InvoiceDetails { get; set; } = new List<ViewInvoiceDetail>();
    }
}
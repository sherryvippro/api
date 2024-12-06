using _api.Models;

namespace _api.InputModels
{
    public class InputInvoice
    {
        public string InvoiceId { get; set; } = null!;
        public DateTime SaleDate { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<InputInvoiceDetail> InvoiceDetails { get; set; } = new List<InputInvoiceDetail>();
    }
}

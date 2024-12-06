using _api.Models;

namespace _api.ViewModel
{
    public class Invoice
    {
        public string SoHdb { get; set; } = null!;

        public DateTime NgayBan { get; set; }

        public decimal TongHdb { get; set; }

        public string HoTen { get; set; }

        public ICollection<InvoiceDetail> TChiTietHdbs { get; set; } = new List<InvoiceDetail>();
    }
}

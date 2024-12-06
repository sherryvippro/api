using _api.Models;

namespace _api.ViewModel
{
    public class InvoiceDetail
    {
        public string SoHdb { get; set; } = null!;

        public string MaSp { get; set; } = null!;

        public int Slban { get; set; }

        public string? KhuyenMai { get; set; }
        public int? ThanhTien { get; set; }

        public string TenSp { get; set; }
    }
}

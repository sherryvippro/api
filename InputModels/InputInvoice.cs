using _api.Models;

namespace _api.InputModels
{
    public class InputInvoice
    {
        public string SoHdb { get; set; } = null!;
        public DateTime NgayBan { get; set; }
        public int MaNguoiDung { get; set; }
        public decimal TongHdb { get; set; }
        public ICollection<InputInvoiceDetail> TChiTietHdbs { get; set; } = new List<InputInvoiceDetail>();
    }
}

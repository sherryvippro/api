
namespace _api.InputModels
{
    public class InputInvoiceDetail
    {
        public string SoHdb { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public int Slban { get; set; }
        public string? KhuyenMai { get; set; }
    }
}

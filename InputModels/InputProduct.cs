
namespace _api.InputModels
{
    public class InputProduct
    {
        public string MaSp { get; set; } = null!;
        public string TenSp { get; set; } = null!;
        public string MaTl { get; set; } = null!;
        public string MaHang { get; set; } = null!;
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuong { get; set; }
        public string? Anh {  get; set; }

    }
}

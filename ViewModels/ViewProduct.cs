namespace _api.ViewModels
{
    public class ViewProduct
    {
        public string ProductId { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public string CategoryId { get; set; } = null!;

        public string ManufacturerId { get; set; } = null!;

        public decimal InPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int Quantity { get; set; }

        public string? Image { get; set; }
    }
}

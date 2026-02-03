namespace MonkCommerce.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;

        public CouponType Type { get; set; }

        public decimal DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }

        // Only used when Type = ProductWise
        public List<int>? ProductIds { get; set; }
    }
}

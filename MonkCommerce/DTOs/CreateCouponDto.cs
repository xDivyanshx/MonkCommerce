using System.ComponentModel.DataAnnotations;
using MonkCommerce.Models;

namespace MonkCommerce.DTOs
{
    public class CreateCouponDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public CouponType Type { get; set; }

        [Range(1, 100)]
        public decimal DiscountPercentage { get; set; }

        public DateTime ExpiryDate { get; set; }

        // Required only for ProductWise coupons
        public List<int>? ProductIds { get; set; }
    }
}

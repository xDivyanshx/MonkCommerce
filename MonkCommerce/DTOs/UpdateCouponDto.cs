using System.ComponentModel.DataAnnotations;

namespace MonkCommerce.DTOs
{
    public class UpdateCouponDto
    {
        [Range(1, 100)]
        public decimal DiscountPercentage { get; set; }

        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}

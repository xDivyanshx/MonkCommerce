using System.ComponentModel.DataAnnotations;

namespace MonkCommerce.DTOs
{
    public class CreateCouponDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;

        [Range(1, 100)]
        public decimal DiscountPercentage { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}

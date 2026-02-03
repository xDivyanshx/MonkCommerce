using MonkCommerce.Models;
using MonkCommerce.Services.Interfaces;

namespace MonkCommerce.Services
{
    public class CouponService : ICouponService
    {
        private static readonly List<Coupon> _coupons = new();
        private static int _idCounter = 1;

        public Coupon Create(Coupon coupon)
        {
            coupon.Id = _idCounter++;
            coupon.IsActive = true;
            _coupons.Add(coupon);
            return coupon;
        }

        public IEnumerable<Coupon> GetAll()
        {
            return _coupons;
        }

        public Coupon Get(int id)
        {
            foreach (var coupon in _coupons)
            {
                if (coupon.Id == id)
                {
                    return coupon;
                }
            }
            return null;
            
        }

        public Coupon? Update(int id, Coupon updatedCoupon)
        {
            var existing = _coupons.FirstOrDefault(c => c.Id == id);
            if (existing == null) return null;

            existing.DiscountPercentage = updatedCoupon.DiscountPercentage;
            existing.ExpiryDate = updatedCoupon.ExpiryDate;
            existing.IsActive = updatedCoupon.IsActive;

            return existing;
        }

        public bool Delete(int id)
        {
            var coupon = _coupons.FirstOrDefault(c => c.Id == id);
            if (coupon == null) return false;

            _coupons.Remove(coupon);
            return true;
        }
    }
}

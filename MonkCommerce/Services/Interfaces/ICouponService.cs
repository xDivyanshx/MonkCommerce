using MonkCommerce.Models;

namespace MonkCommerce.Services.Interfaces
{
    public interface ICouponService
    {
        Coupon Create(Coupon coupon);
        IEnumerable<Coupon> GetAll();
        Coupon Get(int id);
        Coupon? Update(int id, Coupon coupon);
        bool Delete(int id);
    }
}

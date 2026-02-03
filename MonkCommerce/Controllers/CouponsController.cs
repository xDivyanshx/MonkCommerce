using Microsoft.AspNetCore.Mvc;
using MonkCommerce.DTOs;
using MonkCommerce.Models;
using MonkCommerce.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class CouponsController : ControllerBase
{
    private readonly ICouponService _couponService;

    public CouponsController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpPost]
    public IActionResult Create(CreateCouponDto dto)
    {
        try
        {
            var coupon = new Coupon
            {
                Code = dto.Code,
                Type = dto.Type,
                DiscountPercentage = dto.DiscountPercentage,
                ExpiryDate = dto.ExpiryDate,
                ProductIds = dto.ProductIds
            };

            var created = _couponService.Create(coupon);

            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var coupon = _couponService.Get(id);
        if (coupon == null)
            return NotFound();

        return Ok(coupon);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_couponService.GetAll());
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateCouponDto dto)
    {
        var updatedCoupon = new Coupon
        {
            DiscountPercentage = dto.DiscountPercentage,
            ExpiryDate = dto.ExpiryDate,
            IsActive = dto.IsActive
        };

        var result = _couponService.Update(id, updatedCoupon);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _couponService.Delete(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}

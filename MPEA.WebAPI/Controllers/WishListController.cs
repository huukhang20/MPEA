using Microsoft.AspNetCore.Mvc;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.WishlistRequest;
using MPEA.Domain.Models;

namespace MPEA.WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WishlistController : ControllerBase
{
    private readonly IWishlistService _wishlistService;

    public WishlistController(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWishListItem([FromBody] WishlistRequest wishlistRequest)
    {
        if (wishlistRequest == null)
        {
            return BadRequest("WishList request cannot be null.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _wishlistService.CreateWishList(wishlistRequest);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWishlist(string id)
    {
        // Gọi hàm Delete từ service
        var wishlist = await _wishlistService.DeleteAsyncWishList(id);

        // Kiểm tra nếu không tìm thấy wishlist
        if (wishlist == null)
        {
            return NotFound(new { message = "Wishlist not found." });
        }

        // Trả về kết quả xoá thành công
        return Ok(new { message = "Wishlist deleted successfully.", wishlist });
    }
}

using Microsoft.AspNetCore.Mvc;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.WishlistRequest;

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
    public async Task<IActionResult> CreateWishlistItem([FromBody] WishlistRequest wishlistRequest)
    {
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
}

using MPEA.Application.Model.RequestModel.WishlistRequest;
using MPEA.Application.Model.ViewModel.WishList;
using MPEA.Domain.Models;

namespace MPEA.Application.IService;

public interface IWishlistService
{
    Task<Wishlist> CreateWishList(WishlistRequest wishlistRequest);
    Task<List<WishListResponse>> GetAllWishList();
    Task<WishListResponse> GetWishListById(string id);
    Task<(List<WishListResponse>?, int)> GetWishListByAccountId(string id);
    // Task<Wishlist> UpdateWishList(UpdateWishlistRequest updateWishlistRequest);
    // Task<Wishlist> DeleteWishList(string id);
}
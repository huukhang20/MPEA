using MPEA.Application.Model.RequestModel.WishlistRequest;
using MPEA.Domain.Models;

namespace MPEA.Application.IRepository;

public interface IWishlistRepository : IGenericRepository<Wishlist>
{
    public Task<List<Wishlist>> GetAllByAccount();
    public Task<List<Wishlist>> GetByIdAsync(string id);
    public Task<List<Wishlist>> GetWishListByAccountId(string id);
    
}
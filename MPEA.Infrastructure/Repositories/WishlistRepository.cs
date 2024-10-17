using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Models;

namespace MPEA.Infrastructure.Repositories;

public class WishlistRepository : GenericRepository<Wishlist> , IWishlistRepository
{
    public WishlistRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Wishlist>> GetAllByAccount()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<List<Wishlist>> GetByIdAsync(string id)
    {
        return await DbSet.Where(n => n.UserId == id.ToString()).ToListAsync();
    }

    public async Task<List<Wishlist>> GetWishListByAccountId(string id)
    {
        return await DbSet.Where(w => w.UserId == id).ToListAsync();
    }
}
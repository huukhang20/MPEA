using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Enum;
using MPEA.Domain.Models;

namespace MPEA.Infrastructure.Repositories;

public class ExchangeRepository : GenericRepository<Exchange>, IExchangeRepository
{
    public ExchangeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Exchange>> GetByUserId(Guid userId, int pageNumber, int pageSize)
    {
        return await DbSet
                        .Where(e => e.ProviderId.Equals(userId) || e.OffererId.Equals(userId))
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
    }
}
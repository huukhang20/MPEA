using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Models;

namespace MPEA.Infrastructure.Repositories;

public class SparePartRepository : GenericRepository<SparePart>, ISparePartRepository
{
    public SparePartRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<SparePart>> GetByName(string query)
    {
        return await DbSet.Where(e => e.Name.ToLower().Contains(query.ToLower())).ToListAsync();
    }

    public async Task<List<SparePart>> GetByCateName(string query)
    {
        return await DbSet.Where(e => e.Category.Name.ToLower().Contains(query.ToLower())).ToListAsync();
    }
}
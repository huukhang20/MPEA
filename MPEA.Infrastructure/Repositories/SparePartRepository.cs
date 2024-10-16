using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Models;

namespace MPEA.Infrastructure.Repositories;

public class SparePartRepository : GenericRepository<SparePart>, ISparePartRepository
{
    private readonly AppDbContext _context;
    public SparePartRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<SparePart>> GetAllSparePartAsync()
    {
        var partlist = await DbSet.ToListAsync();
        return partlist;
    }

    public async Task<SparePart> GetSparePartById(int id)
    {
        return await DbSet.FirstOrDefaultAsync(p => p.Id == id.ToString());
    }
}
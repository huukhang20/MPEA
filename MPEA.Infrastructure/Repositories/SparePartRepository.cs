using MPEA.Application.IRepository;
using MPEA.Domain.Models;

namespace MPEA.Infrastructure.Repositories;

public class SparePartRepository : GenericRepository<SparePart>, ISparePartRepository
{
    public SparePartRepository(AppDbContext context) : base(context)
    {
    }
}
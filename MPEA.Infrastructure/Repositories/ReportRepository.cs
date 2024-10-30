using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Enum;
using MPEA.Domain.Models;
using MPEA.Domain.Models.BaseModel;

namespace MPEA.Infrastructure.Repositories;

public class ReportRepository : GenericRepository<Report> , IReportRepository
{
    public ReportRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Report>> GetAllReportPendingAsync()
    {
        return await DbSet.Where(x => x.Status == ReportStatus.Pending.ToString()).ToListAsync();
    }
    public  async Task<Report?> GetByIdAsync(string id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id.ToString() == id.ToString() && x.Status != ReportStatus.Inactive.ToString());
    }

    public override async Task<List<Report>> GetAllAsync()
    {
        return await DbSet.Where(x => x.Status != ReportStatus.Inactive.ToString()).ToListAsync();
    }
}
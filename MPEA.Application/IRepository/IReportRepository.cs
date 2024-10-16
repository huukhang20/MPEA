using MPEA.Domain.Models;

namespace MPEA.Application.IRepository;

public interface IReportRepository :  IGenericRepository<Report>
{
   Task<List<Report>> GetAllReportPendingAsync();
   Task<Report?> GetByIdAsync(string id);
}
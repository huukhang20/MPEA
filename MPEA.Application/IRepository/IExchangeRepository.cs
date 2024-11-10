using MPEA.Domain.Models;

namespace MPEA.Application.IRepository;

public interface IExchangeRepository : IGenericRepository<Exchange>
{
    Task<List<Exchange>> GetByUserId(Guid userId, int pageNumber, int pageSize);
}
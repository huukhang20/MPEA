using MPEA.Domain.Models;

namespace MPEA.Application.IRepository;

public interface ISparePartRepository : IGenericRepository<SparePart>
{
    Task<List<SparePart>> GetByName(string query);
    Task<List<SparePart>> GetByCateName(string query);
}
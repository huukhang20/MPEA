using MPEA.Domain.Models;

namespace MPEA.Application.IRepository;

public interface ISparePartRepository : IGenericRepository<SparePart>
{
    Task<List<SparePart>> GetAllSparePartAsync();
    Task<SparePart> GetSparePartById(int id);
    
}
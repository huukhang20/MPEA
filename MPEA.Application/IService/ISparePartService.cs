using MPEA.Application.Model.RequestModel.SparepartRequest;
using MPEA.Domain.Models;

namespace MPEA.Application.IService;

public interface ISparePartService
{
    Task<SparePart> UpdateSparePart(UpdateSparePartRequest request);
    
}
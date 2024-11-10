using MPEA.Application.Model.RequestModel.Exchange;
using MPEA.Application.Model.ViewModel.Exchange;

namespace MPEA.Application.IService;

public interface IExchangeService
{
    Task<List<ExchangeResponse>> GetByUserId(Guid userId, int pageNumber, int pageSize);
    Task<bool> CreateExchange(CreateExchangeRequest request);
    Task<bool> UpdateStatusExchange(UpdateStatusExchangeRequest request, Guid exId);
}
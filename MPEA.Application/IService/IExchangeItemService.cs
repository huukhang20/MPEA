using MPEA.Application.Model.RequestModel.ExchangeItemRequest;
using MPEA.Application.Model.ViewModel.ExchangeItem;

namespace MPEA.Application.IService
{
    public interface IExchangeItemService
    {
        Task<bool> CreateExchangeItem(CreateExItemRequest request);
        Task<List<ExchangeItemResponse>> GetByUserId(Guid userId, int pageNumber, int pageSize);
    }
}

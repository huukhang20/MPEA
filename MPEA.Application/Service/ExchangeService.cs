using AutoMapper;
using Microsoft.CodeAnalysis.Text;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.Exchange;
using MPEA.Application.Model.ViewModel.Exchange;
using MPEA.Domain.Models;

namespace MPEA.Application.Service;

public class ExchangeService : IExchangeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExchangeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> CreateExchange(CreateExchangeRequest request)
    {
        var exchange = _mapper.Map<Exchange>(request);
        await _unitOfWork.ExchangeRepository.AddAsync(exchange);
        var check = await _unitOfWork.SaveChangesAsync() > 0;

        if (check is false)
        {
            return false;
        }

        return true;
    }

    public async Task<List<ExchangeResponse>> GetByUserId(Guid userId, int pageNumber, int pageSize)
    {
        var list = await _unitOfWork.ExchangeRepository.GetByUserId(userId, pageNumber, pageSize);
        var result = _mapper.Map<List<ExchangeResponse>>(list);
        return result;
    }

    public async Task<bool> UpdateStatusExchange(UpdateStatusExchangeRequest request, Guid exId)
    {
        var ex = await _unitOfWork.ExchangeRepository.GetByIdAsync(exId);
        ex = _mapper.Map(request, ex);
        _unitOfWork.ExchangeRepository.Update(ex);
        var check = await _unitOfWork.SaveChangesAsync() > 0;

        if (check is false)
        {
            return false;
        }

        return true;
    }
}
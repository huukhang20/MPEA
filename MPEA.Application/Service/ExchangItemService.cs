using AutoMapper;
using Microsoft.Extensions.Hosting;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.ExchangeItemRequest;
using MPEA.Application.Model.ViewModel.ExchangeItem;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Service
{
    public class ExchangItemService : IExchangeItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExchangItemService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateExchangeItem(CreateExItemRequest request)
        {
            var exItem = _mapper.Map<ExchangeItem>(request);
            await _unitOfWork.ExchangeItemRepository.AddAsync(exItem);
            var check = await _unitOfWork.SaveChangesAsync() > 0;

            if (check is false)
            {
                return false;
            }

            return true;
        }

        public async Task<List<ExchangeItemResponse>> GetByUserId(Guid userId, int pageNumber, int pageSize)
        {
            var list = await _unitOfWork.ExchangeItemRepository.GetByUserId(userId, pageNumber, pageSize);
            var result = _mapper.Map<List<ExchangeItemResponse>>(list);
            return result;
        }
    }
}

using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IRepository
{
    public interface IExchangeItemRepository :  IGenericRepository<ExchangeItem>
    {
        Task<List<ExchangeItem>> GetByUserId(Guid userId, int pageNumber, int pageSize);
    }
}

using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Infrastructure.Repositories
{
    public class ExchangeItemRepository : GenericRepository<ExchangeItem>, IExchangeItemRepository
    {
        public ExchangeItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<ExchangeItem>> GetByUserId(Guid userId, int pageNumber, int pageSize)
        {
            return await DbSet
                            .Where(ei => ei.SparePart.UserId.Equals(userId))
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        }
    }
}

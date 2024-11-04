using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Models;

namespace MPEA.Infrastructure.Repositories;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Payment>> GetMembershipPayment()
    {
        return await DbSet.Where(p => p.MembershipId != null).ToListAsync();
    }
}
using MPEA.Domain.Models;

namespace MPEA.Application.IRepository;

public interface IPaymentRepository : IGenericRepository<Payment>
{
    Task<List<Payment>> GetMembershipPayment();
}
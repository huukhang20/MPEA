using MPEA.Application.Model.ViewModel.Payment;

namespace MPEA.Application.IService;

public interface IPaymentService
{
    Task<List<MembershipPaymentResponse>> GetMembershipPurchased();
}
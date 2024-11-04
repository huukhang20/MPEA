using AutoMapper;
using MPEA.Application.IService;
using MPEA.Application.Model.ViewModel.Payment;

namespace MPEA.Application.Service;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<MembershipPaymentResponse>> GetMembershipPurchased()
    {
        var list = await _unitOfWork.PaymentRepository.GetMembershipPayment();
        var result = _mapper.Map<List<MembershipPaymentResponse>>(list);
        return result;
    }
}
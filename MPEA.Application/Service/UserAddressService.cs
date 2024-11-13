using AutoMapper;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.UserAddressRequest;
using MPEA.Domain.Models;

namespace MPEA.Application.Service;

public class UserAddressService : IUserAddressService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserAddressService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> AddAddress(CreateAddressRequest request)
    {
        var address = _mapper.Map<UserAddress>(request);
        await _unitOfWork.UserAddressRepository.AddAsync(address);
        var check = await _unitOfWork.SaveChangesAsync() > 0;

        if (check is false)
        {
            return false;
        }

        return true;
    }
}
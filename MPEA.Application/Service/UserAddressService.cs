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

    public async Task<bool?> DeleteAddress(Guid id)
    {
        var post = await _unitOfWork.UserAddressRepository.GetByIdAsync(id);
        await _unitOfWork.UserAddressRepository.DeleteAsync(post);
        var check = await _unitOfWork.SaveChangesAsync() > 0;

        if (check is false)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateAddress(Guid id, UpdateAddressRequest request)
    {
        var address = await _unitOfWork.UserAddressRepository.GetByIdAsync(id);
        address = _mapper.Map(request, address);
        _unitOfWork.UserAddressRepository.Update(address);
        var check = await _unitOfWork.SaveChangesAsync() > 0;

        if (check is false)
        {
            return false;
        }

        return true;
    }
}
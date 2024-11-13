using MPEA.Application.Model.RequestModel.UserAddressRequest;
using MPEA.Application.Model.ViewModel.UserAdresses;

namespace MPEA.Application.IService;

public interface IUserAddressService
{
    Task<bool> AddAddress(CreateAddressRequest request);
    Task<bool> UpdateAddress(Guid id, UpdateAddressRequest request);
    Task<bool?> DeleteAddress(Guid id);
}
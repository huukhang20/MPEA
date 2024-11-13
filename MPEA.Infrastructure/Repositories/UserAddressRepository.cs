using MPEA.Application.IRepository;
using MPEA.Domain.Models;

namespace MPEA.Infrastructure.Repositories;

public class UserAddressRepository : GenericRepository<UserAddress>, IUserAddressRepository
{
    public UserAddressRepository(AppDbContext context) : base(context)
    {
    }
}
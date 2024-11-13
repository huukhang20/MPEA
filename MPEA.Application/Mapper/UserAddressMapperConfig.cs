using AutoMapper;
using MPEA.Application.Model.RequestModel.UserAddressRequest;
using MPEA.Application.Model.ViewModel.UserAdresses;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Mapper
{
    public partial class MapperConfig : Profile
    {
        partial void AddUserAddressMapperConfig()
        {
            CreateMap<UserAddress, UserAddressResponse>();
            CreateMap<CreateAddressRequest, UserAddress>();
            CreateMap<UpdateAddressRequest, UserAddress>();
        }
    }
}

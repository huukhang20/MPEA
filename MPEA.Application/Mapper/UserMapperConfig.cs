using AutoMapper;
using MPEA.Application.Model.ViewModel.User;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPEA.Application.Model.ViewModel.SparePart;

namespace MPEA.Application.Mapper
{
    public partial class MapperConfig : Profile
    {
        partial void AddUserMapperConfig()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<SparePart, SparePartResponse>().ReverseMap();
        }
    }
}

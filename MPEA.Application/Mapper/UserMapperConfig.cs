using AutoMapper;
using MPEA.Application.Model.ViewModel.Chat;
using MPEA.Application.Model.ViewModel.Notification;
using MPEA.Application.Model.ViewModel.User;
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
        partial void AddUserMapperConfig()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<Chat, ChatResponse>().ReverseMap();
            
        }
    }
}

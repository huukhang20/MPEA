using AutoMapper;
using MPEA.Application.Model.RequestModel.PostRequest;
using MPEA.Application.Model.ViewModel.PostResponse;
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
        partial void AddPostMapperConfig()
        {
            CreateMap<CreatePostRequest, Post>();
            CreateMap<UpdatePostRequest, Post>();

            CreateMap<Post, PostResponse>()
                .ForMember(rs => rs.UserCode, act => act.MapFrom(p => p.User.Code));
        }
    }
}

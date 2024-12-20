﻿using AutoMapper;
using MPEA.Application.Model.RequestModel.Authentication;
using MPEA.Application.Model.ViewModel.Category;
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
        partial void AddCateMapperConfig()
        {
            CreateMap<Category, CategoryNameResponse>();
        }
    }
}

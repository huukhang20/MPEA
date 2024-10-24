﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Mapper
{
    public partial class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AddUserMapperConfig();
            AddCateMapperConfig();
            AddSparePartMapperConfig();
            AddNotificationMapperConfig();
            AddReportMapperConfig();
           AddWishListMapperConfig();
        }

        partial void AddUserMapperConfig();
        partial void AddCateMapperConfig();
        partial void AddSparePartMapperConfig();
        partial void AddNotificationMapperConfig();
        partial void AddReportMapperConfig();
        partial void AddWishListMapperConfig();
    }
}

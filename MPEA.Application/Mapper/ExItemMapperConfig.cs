using AutoMapper;
using MPEA.Application.Model.RequestModel.ExchangeItemRequest;
using MPEA.Application.Model.ViewModel.ExchangeItem;
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
        partial void AddExItemMapperConfig()
        {
            CreateMap<CreateExItemRequest, ExchangeItem>();
            CreateMap<ExchangeItem, ExchangeItemResponse>();
        }
    }
}

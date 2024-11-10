using AutoMapper;
using MPEA.Application.Model.RequestModel.Exchange;
using MPEA.Application.Model.ViewModel.Exchange;
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
        partial void AddExchangeMapperConfig()
        {
            CreateMap<Exchange, ExchangeResponse>();
            CreateMap<CreateExchangeRequest, Exchange>();
            CreateMap<UpdateStatusExchangeRequest, Exchange>();
        }
    }
}

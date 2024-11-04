using AutoMapper;
using MPEA.Application.Model.RequestModel.ReportRequest;
using MPEA.Application.Model.ViewModel.Payment;
using MPEA.Application.Model.ViewModel.Report;
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
        partial void AddPaymentMapperConfig()
        {
            CreateMap<Payment, MembershipPaymentResponse>()
                .ForMember(p => p.Membership, act => act.MapFrom(pm => pm.Membership.Name))
                .ForMember(p => p.UserCode, act => act.MapFrom(pm => pm.Payer.Code));
        }
    }
}

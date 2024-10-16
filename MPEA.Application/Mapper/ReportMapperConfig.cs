using AutoMapper;
using MPEA.Application.Model.RequestModel.ReportRequest;
using MPEA.Application.Model.ViewModel.Report;
using MPEA.Domain.Models;

namespace MPEA.Application.Mapper;

public partial class MapperConfig  : Profile
{
    partial void AddReportMapperConfig()
    {
        CreateMap<Report, ReportRequest>().ReverseMap();
        CreateMap<Report, UpdateReportRequest>().ReverseMap();
        CreateMap<Report, ReportResponse>().ReverseMap();
    }
}
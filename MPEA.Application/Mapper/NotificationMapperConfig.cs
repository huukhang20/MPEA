using AutoMapper;
using MPEA.Application.Model.RequestModel.NotificationRequest;
using MPEA.Application.Model.ViewModel.Notification;
using MPEA.Domain.Models;

namespace MPEA.Application.Mapper;

public partial class MapperConfig : Profile
{
    partial void AddNotificationMapperConfig()
    {
        CreateMap<NotificationRequest, Notification>();
        CreateMap<Notification, NotificationResponse>().ReverseMap();
        CreateMap<Notification, NotificationDetailResponse>().ReverseMap();
    }
}
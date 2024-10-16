using MPEA.Application.BaseModel;
using MPEA.Application.Model.RequestModel.NotificationRequest;
using MPEA.Application.Model.ViewModel.Notification;
using MPEA.Domain.Models;

namespace MPEA.Application.IService;

public interface INotificationService
{
    public Task<bool> CreateNotification(NotificationRequest notification);
    public Task<List<NotificationResponse>> Get5Notification(int id);
    public Task<NotificationDetailResponse?> GetNotificationById(int id);
    public Task<(List<NotificationResponse>?, int)> GetNotificationByAccountId(ListModels listModelsint , int id);
    public Task<bool> ReadNotification(int id);
}
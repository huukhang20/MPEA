using MPEA.Domain.Models;

namespace MPEA.Application.IRepository;

public interface INotificationRepository : IGenericRepository<Notification>
{
    public Task<List<Notification>> GetAllByAccount(int id);
    public Task<List<Notification>> Get5NotificationOfUser(int id);
    public Task<Notification> GetByIdAsync(int id);
    public Task<List<Notification>> GetNotifications(int pageNumber, int pageSize);
}
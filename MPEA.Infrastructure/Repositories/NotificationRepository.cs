using MPEA.Application.IRepository;
using MPEA.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MPEA.Infrastructure.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Notification>> Get5NotificationOfUser(int id)
    {
        return (await DbSet.Where(n => n.UserId != null && n.UserId == id.ToString()).Take(5).ToListAsync());
    }

    public async Task<List<Notification>> GetAllByAccount(int id)
    {
        return await DbSet.Where(n => n.UserId == id.ToString()).ToListAsync();
    }
}
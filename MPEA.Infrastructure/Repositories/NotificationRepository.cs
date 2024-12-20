﻿using MPEA.Application.IRepository;
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
        return (await DbSet.Where(n => n.UserId != null && n.UserId.ToString() == id.ToString()).Take(5).ToListAsync());
    }

    public async Task<Notification> GetByIdAsync(int id)
    {
        return await DbSet.FirstOrDefaultAsync(n => n.Id.ToString() == id.ToString());
    }

    public async Task<List<Notification>> GetAllByAccount(int id)
    {
        return await DbSet.Where(n => n.UserId.ToString() == id.ToString()).ToListAsync();
    }

    public async Task<List<Notification>> GetNotifications(int pageNumber, int pageSize)
    {
        return await DbSet
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
    }
}
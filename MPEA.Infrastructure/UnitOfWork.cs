﻿using MPEA.Application;
using MPEA.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IUserRepository userRepository, ICategoryRepository categoryRepository, ISparePartRepository sparePartRepository, IWishlistRepository wishlistRepository, IReportRepository reportRepository, INotificationRepository notificationRepository)
        {
            _context = context;
            UserRepository = userRepository;
            CategoryRepository = categoryRepository;
            SparePartRepository = sparePartRepository;
            WishlistRepository = wishlistRepository;
            ReportRepository = reportRepository;
            NotificationRepository = notificationRepository;
        }

        public IUserRepository UserRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ISparePartRepository SparePartRepository {  get; }
        public IWishlistRepository WishlistRepository { get; }
        public IReportRepository ReportRepository { get; }
        public INotificationRepository NotificationRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}

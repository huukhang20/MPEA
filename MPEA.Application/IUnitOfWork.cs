﻿using MPEA.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ISparePartRepository SparePartRepository { get; }
        public IWishlistRepository WishlistRepository { get; }
        public IReportRepository ReportRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IPostRepository PostRepository { get; }
        public IExchangeRepository ExchangeRepository { get; }
        public IExchangeItemRepository ExchangeItemRepository { get; }
        public IUserAddressRepository UserAddressRepository { get; }
        public Task<int> SaveChangesAsync();
    }
}

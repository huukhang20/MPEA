using MPEA.Application.IRepository;
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
        public ISparePartRepository SparePartRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IReportRepository ReportRepository { get; }
        public IWishlistRepository WishlistRepository { get; }
        public Task<int> SaveChangesAsync();
    }
}

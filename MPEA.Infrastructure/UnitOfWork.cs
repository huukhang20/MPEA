using MPEA.Application;
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

        public UnitOfWork(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }

    }
}

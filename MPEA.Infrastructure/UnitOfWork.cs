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

        public UnitOfWork(AppDbContext context, IUserRepository userRepository, ICategoryRepository categoryRepository, ISparePartRepository sparePartRepository)
        {
            _context = context;
            UserRepository = userRepository;
            CategoryRepository = categoryRepository;
            SparePartRepository = sparePartRepository;
        }

        public IUserRepository UserRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ISparePartRepository SparePartRepository {  get; }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}

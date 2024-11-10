using Microsoft.EntityFrameworkCore;
using MPEA.Application.IRepository;
using MPEA.Domain.Enum;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Infrastructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Post>> GetPostByUserId(Guid userId, int pageNumber, int pageSize)
        {
            return await DbSet.Where(p => p.UserId.Equals(userId))
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        }

            public async Task<List<Post>> GetPosts(int pageNumber, int pageSize)
        {
            var list = await DbSet
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
            return list;
        }
    }
}

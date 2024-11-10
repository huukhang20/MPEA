using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<Post>> GetPosts(int pageNumber, int pageSize);
        Task<Post> GetPostByUserId(Guid userId);
    }
}

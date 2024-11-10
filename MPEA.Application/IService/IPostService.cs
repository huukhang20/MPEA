using MPEA.Application.Model.RequestModel.PostRequest;
using MPEA.Application.Model.ViewModel.PostResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IService
{
    public interface IPostService
    {
        Task<bool> CreatePost(CreatePostRequest request);
        Task<List<PostResponse>> GetPosts(int pageNumber, int pageSize);
        Task<PostResponse> GetPostById(Guid postId);
        Task<List<PostResponse>> GetPostByUserId(Guid userId, int pageNumber, int pageSize);
        Task<bool> DeletePost(Guid postId);
        Task<bool> UpdatePost(Guid postId, UpdatePostRequest post);
    }
}

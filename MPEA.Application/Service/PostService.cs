using AutoMapper;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.PostRequest;
using MPEA.Application.Model.ViewModel.PostResponse;
using MPEA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> CreatePost(CreatePostRequest request)
        {
            var post = mapper.Map<Post>(request);
            await _unitOfWork.PostRepository.AddAsync(post);
            var check = await _unitOfWork.SaveChangesAsync() > 0;

            if (check is false)
            {
                return false;
            }
            
            return true;
        }

        public async Task<bool> DeletePost(Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(postId);
            await _unitOfWork.PostRepository.DeleteAsync(post);
            var check = await _unitOfWork.SaveChangesAsync() > 0;

            if (check is false)
            {
                return false;
            }

            return true;
        }

        public async Task<PostResponse> GetPostById(Guid postId)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(postId);
            var result = mapper.Map<PostResponse>(post);
            return result;
        }

        public async Task<List<PostResponse>> GetPostByUserId(Guid userId, int pageNumber, int pageSize)
        {
            var post = await _unitOfWork.PostRepository.GetPostByUserId(userId, pageNumber, pageSize);
            var result = mapper.Map<List<PostResponse>>(post);
            return result;
        }

        public async Task<List<PostResponse>> GetPosts(int pageNumber, int pageSize)
        {
            var list = await _unitOfWork.PostRepository.GetPosts(pageNumber, pageSize);
            var result = mapper.Map<List<PostResponse>>(list);
            return result;
        }

        public async Task<bool> UpdatePost(Guid postId, UpdatePostRequest request)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(postId);
            post = mapper.Map(request, post);
            _unitOfWork.PostRepository.Update(post);
            var check = await _unitOfWork.SaveChangesAsync() > 0;

            if (check is false)
            {
                return false;
            }

            return true;
        }
    }
}

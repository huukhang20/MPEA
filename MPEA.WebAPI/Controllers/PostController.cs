using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.PostRequest;
using MPEA.Domain.Models;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = await _postService.GetPosts(pageNumber, pageSize);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Post created successfully.",
                    Response = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedModel
                {
                    Status = BadRequest().StatusCode,
                    Message = ex.Message,
                    Result = false,
                    Errors = ex
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            try
            {
                var result = await _postService.GetPostById(id);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Successfully.",
                    Response = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedModel
                {
                    Status = BadRequest().StatusCode,
                    Message = ex.Message,
                    Result = false,
                    Errors = ex
                });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPostByUserId(Guid userId)
        {
            try
            {
                var result = await _postService.GetPostByUserId(userId);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Successfully.",
                    Response = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedModel
                {
                    Status = BadRequest().StatusCode,
                    Message = ex.Message,
                    Result = false,
                    Errors = ex
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostRequest request)
        {
            try
            {
                var result = await _postService.CreatePost(request);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Post created successfully.",
                    Response = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedModel
                {
                    Status = BadRequest().StatusCode,
                    Message = ex.Message,
                    Result = false,
                    Errors = ex
                });
            }
        }


    }
}

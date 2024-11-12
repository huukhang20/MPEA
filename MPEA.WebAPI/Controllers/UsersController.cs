using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Domain.Models;
using System.Drawing.Printing;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userSerevice;

        public UsersController(IUserService userSerevice)
        {
            _userSerevice = userSerevice;
        }

        // GET: api/Users
        [HttpGet()]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var response = await _userSerevice.GetAllAccount();

                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Get users successed",
                    Response = response
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseFailedModel
                {
                    Status = Ok().StatusCode,
                    Message = ex.Message,
                    Result = new List<User>(),
                    Errors = ex
                });
            }
        }

        [HttpGet("exchangers")]
        public async Task<ActionResult> GetExchangers(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var response = await _userSerevice.GetExchangers(pageNumber, pageSize);

                return Ok(new PaginatedModel
                {
                    Status = Ok().StatusCode,
                    Message = "Get exchangers successed",
                    Response = response,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = response.Count()
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseFailedModel
                {
                    Status = Ok().StatusCode,
                    Message = ex.Message,
                    Result = new List<User>(),
                    Errors = ex
                });
            }
        }

        [HttpGet("staffs")]
        public async Task<ActionResult> GetStaffs(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var response = await _userSerevice.GetStaffs(pageNumber, pageSize);

                return Ok(new PaginatedModel
                {
                    Status = Ok().StatusCode,
                    Message = "Get staffs successed",
                    Response = response,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = response.Count()
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseFailedModel
                {
                    Status = Ok().StatusCode,
                    Message = ex.Message,
                    Result = new List<User>(),
                    Errors = ex
                });
            }
        }

        [HttpGet("{id}/messages")]
        public async Task<IActionResult> GetMessagesForExchanger(Guid id, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var response = await _userSerevice.GetExchangerMessage(id, pageNumber, pageSize);

                return Ok(new PaginatedModel
                {
                    Status = Ok().StatusCode,
                    Message = "Get staffs successed",
                    Response = response,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = response.Count()
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseFailedModel
                {
                    Status = Ok().StatusCode,
                    Message = ex.Message,
                    Result = new List<User>(),
                    Errors = ex
                });
            }
        }

        [HttpGet("{id}/addresses")]
        public async Task<ActionResult> GetUserAddress(Guid id, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var response = await _userSerevice.GetUserAddress(id, pageNumber, pageSize);

                return Ok(new PaginatedModel
                {
                    Status = Ok().StatusCode,
                    Message = "Successfully",
                    Response = response,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = response.Count()
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseFailedModel
                {
                    Status = Ok().StatusCode,
                    Message = ex.Message,
                    Result = new List<User>(),
                    Errors = ex
                });
            }
        }

        [HttpGet("{id}/transactions")]
        public async Task<ActionResult> GetUserTransactions(Guid id, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var response = await _userSerevice.GetUserTransasction(id, pageNumber, pageSize);

                return Ok(new PaginatedModel
                {
                    Status = Ok().StatusCode,
                    Message = "Successfully",
                    Response = response,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = response.Count()
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseFailedModel
                {
                    Status = Ok().StatusCode,
                    Message = ex.Message,
                    Result = new List<User>(),
                    Errors = ex
                });
            }
        }

        private bool UserExists(string id)
        {
            throw new NotImplementedException();
        }
    }
}

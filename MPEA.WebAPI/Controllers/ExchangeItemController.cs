using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.ExchangeItemRequest;
using MPEA.Application.Service;
using MPEA.Domain.Models;
using System.Drawing.Printing;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/exchange-items")]
    [ApiController]
    public class ExchangeItemController : ControllerBase
    {
        private readonly IExchangeItemService _exchangeItemService;

        public ExchangeItemController(IExchangeItemService exchangeItemService)
        {
            _exchangeItemService = exchangeItemService;
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId, int pageNumber = 1, int pageSize = 10) 
        {
            try
            {
                var result = await _exchangeItemService.GetByUserId(userId, pageNumber, pageSize);
                return Ok(new PaginatedModel
                {
                    Status = Ok().StatusCode,
                    Message = "Successfully.",
                    Response = result,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = result.Count()
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
        public async Task<IActionResult> CreateExchangeItem(CreateExItemRequest request)
        {
            try
            {
                var result = await _exchangeItemService.CreateExchangeItem(request);
                if (result is true)
                {
                    return Ok(new BaseResponseModel
                    {
                        Status = Ok().StatusCode,
                        Message = "Successfully.",
                        Response = result
                    });
                }
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Failed.",
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

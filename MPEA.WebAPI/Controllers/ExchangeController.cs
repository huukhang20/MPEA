using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.Exchange;
using MPEA.Application.Service;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/exchanges")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = await _exchangeService.GetByUserId(userId, pageNumber, pageSize);
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
        public async Task<IActionResult> CreateExchange(CreateExchangeRequest request)
        {
            try
            {
                var result = await _exchangeService.CreateExchange(request);
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

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateExchangeStatus(UpdateStatusExchangeRequest request, Guid id)
        {
            try
            {
                var result = await _exchangeService.UpdateStatusExchange(request, id);
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

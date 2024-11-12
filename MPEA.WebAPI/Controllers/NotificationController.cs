using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.ViewModel.Notification;
using MPEA.Application.Service;

namespace MPEA.WebAPI.Controllers;
[ApiController]
[Route("api/notifications/")]
public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetNotification(int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            var result = await _notificationService.GetNotifications(pageNumber, pageSize);
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

    [HttpGet("get5notification/{id}")]
    public async Task<IActionResult> Get5Notification([FromRoute] int id)
    {
        try
        {
            var list = await _notificationService.Get5Notification(id);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Lấy 5 thông báo thành công",
                Result = new
                {
                    List = list
                }
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedModel()
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotificationById([FromRoute] int id)
    {
        try
        {
            var result = await _notificationService.GetNotificationById(id);
            if (result == null) return NotFound(new { Success = false, Message = "Notification not found" });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Lấy chi tiết thông báo thành công",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedModel()
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }
    [HttpPatch("{id}")]
    public async Task<IActionResult> IsReadNotification([FromRoute] int id)
    {
        try
        {
            var result = await _notificationService.ReadNotification(id);
            if (!result) return NotFound();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Result = result,
                Message = "Successfully"
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedModel()
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Errors = ex
            });
        }
    }
    [HttpGet("getallnotificationbyacountwithpagination")]
    public async Task<IActionResult> GetAllNotiWithPagination([FromQuery] ListModels listCompetitorModel,
        int userId)
    {
        try
        {
            var (list, totalPage) =
                await _notificationService.GetNotificationByAccountId(listCompetitorModel, userId);
            if (totalPage < listCompetitorModel.PageNumber)
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Trang vượt quá số lượng trang cho phép."
                });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Lấy danh sách thành công",
                Result = new
                {
                    List = list,
                    TotalPage = totalPage
                }
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedModel()
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = new
                {
                    List = new List<NotificationResponse>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }
}
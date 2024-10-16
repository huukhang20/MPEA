using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Domain.Models;

namespace MPEA.WebAPI.Controllers;
[ApiController]
[Route("api/reports/")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
   

    [HttpPatch]
    public async Task<IActionResult> DeleteReport(string id)
    {
        try
        {
            var result = await _reportService.DeleteReport(id);
            if (!result) return NotFound();
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Result = result,
                Message = "Xóa báo cáo thành công"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseFailedModel()
            {
                Status = BadRequest().StatusCode,
                Message = ex.Message,
                Result = false,
                Errors = ex
            });
        }
    }
    [HttpGet("getallreportpending")]
    public async Task<IActionResult> GetAllReportPending([FromQuery] ListModels listReportModel)
    {
        try
        {
            var (list, totalPage) = await _reportService.GetAllReportPending(listReportModel);
            if (totalPage < listReportModel.PageNumber)
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Trang vượt quá số lượng trang cho phép."
                });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Lấy danh sách các báo cáo ",
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
                    List = new List<Report>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }
    [HttpGet("getallreport")]
    public async Task<IActionResult> GetAllReport([FromQuery] ListModels listReportModel)
    {
        try
        {
            var (list, totalPage) = await _reportService.GetAllReport(listReportModel);
            if (totalPage < listReportModel.PageNumber)
                return NotFound(new BaseResponseModel
                {
                    Status = NotFound().StatusCode,
                    Message = "Trang vượt quá số lượng trang cho phép."
                });
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Lấy danh sách các báo cáo thành công",
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
                    List = new List<Report>(),
                    TotalPage = 0
                },
                Errors = ex
            });
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReportById([FromRoute] String id)
    {
        try
        {
            var result = await _reportService.GetReportById(id);
            return Ok(new BaseResponseModel
            {
                Status = Ok().StatusCode,
                Message = "Lấy thông tin báo cáo thành công",
                Result = result
            });
        }
        catch (Exception ex)
        {
            return Ok(new BaseFailedModel()
            {
                Status = Ok().StatusCode,
                Message = ex.Message,
                Result = false,
                Errors = ex
            });
        }
    }

}
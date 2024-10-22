using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.SparePart;
using MPEA.Domain.Models;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/spare-parts")]
    [ApiController]
    public class SparePartController : ControllerBase
    {
        private readonly ISparePartService _sparePartService;

        public SparePartController(ISparePartService sparePartService)
        {
            _sparePartService = sparePartService;
        }

        [HttpPost("spare-part")]
        public async Task<IActionResult> CreateSparePart(CreateSparePartRequest request)
        {
            try
            {
                var result = await _sparePartService.CreateSparePart(request);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Success",
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

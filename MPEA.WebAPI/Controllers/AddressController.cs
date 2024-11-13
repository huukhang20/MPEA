using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.PostRequest;
using MPEA.Application.Model.RequestModel.UserAddressRequest;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;

        [HttpPost]
        public async Task<IActionResult> AddAddress(CreateAddressRequest request)
        {
            try
            {
                var result = await _userAddressService.AddAddress(request);
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
                    Message = "Fail.",
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

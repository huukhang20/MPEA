using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Model.RequestModel.PostRequest;
using MPEA.Application.Model.RequestModel.UserAddressRequest;
using MPEA.Application.Service;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;

        public AddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] UpdateAddressRequest request)
        {
            try
            {
                var result = await _userAddressService.UpdateAddress(id, request);

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            try
            {
                var result = await _userAddressService.DeleteAddress(id);

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

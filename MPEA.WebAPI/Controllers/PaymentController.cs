using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Application.Service;
using MPEA.Domain.Models;

namespace MPEA.WebAPI.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("membership-payments")]
        public async Task<IActionResult> MembershipPurchased()
        {
            try
            {
                var response = await _paymentService.GetMembershipPurchased();

                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Get membership payment",
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
    }
}

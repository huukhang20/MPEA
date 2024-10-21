    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPEA.Application.BaseModel;
using MPEA.Application.IService;
using MPEA.Domain.Models;
using MPEA.Infrastructure;

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
                    Message = "Get user successe",
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

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            throw new NotImplementedException();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostUser(User user)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        private bool UserExists(string id)
        {
            throw new NotImplementedException();
        }
    }
}

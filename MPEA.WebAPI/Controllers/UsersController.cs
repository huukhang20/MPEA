﻿    using System;
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

        private bool UserExists(string id)
        {
            throw new NotImplementedException();
        }
    }
}

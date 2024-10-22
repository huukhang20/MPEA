﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.Model.RequestModel.Authentication
{
    public class UpdateUserRequest
    {
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
    }
}

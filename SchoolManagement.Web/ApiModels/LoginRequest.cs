﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Web.ApiModels
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
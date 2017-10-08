﻿using BlogSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Infrastructure.Attributes
{
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        public AuthorizeAdminAttribute()
        {
            Roles = GlobalConstants.AdminRole;
        }
    }
}
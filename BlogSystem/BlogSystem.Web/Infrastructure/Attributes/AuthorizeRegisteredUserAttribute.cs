using BlogSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Infrastructure.Attributes
{
    public class AuthorizeRegisteredUserAttribute : AuthorizeAttribute
    {
        public AuthorizeRegisteredUserAttribute()
        {
            Roles = GlobalConstants.RegisteredUserRole;
        }
    }
}
using BlogSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId()
        {
            return User.Identity.GetUserId();
        }
    }
}

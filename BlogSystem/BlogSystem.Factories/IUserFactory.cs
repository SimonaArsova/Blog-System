using BlogSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Factories
{
    public interface IUserFactory
    {
        User CreateUser();

        User CreateUser(string username, string email);
    }
}

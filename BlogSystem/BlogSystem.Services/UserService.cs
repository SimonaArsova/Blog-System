using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using BlogSystem.Services.Contracts;
using System;

namespace BlogSystem.Services
{
    public class UserService: IUserService
    {
        private readonly IEfRepository<User> userRepo;
        private readonly ISaveContext context;

        public UserService(IEfRepository<User> userRepo, ISaveContext context)
        {
            this.userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User GetById(string id)
        {
            return this.userRepo.GetById(id);
        }
    }
}

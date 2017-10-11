﻿using BlogSystem.Data.Model;
using BlogSystem.Data.Repositories;
using BlogSystem.Data.SaveContext;
using BlogSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services
{
    public class UserService: IUserService
    {
        private readonly IEfRepository<User> userRepo;
        private readonly ISaveContext context;

        public UserService(IEfRepository<User> userRepo, ISaveContext context)
        {
            this.userRepo = userRepo;
            this.context = context;
        }

        public User GetById(string id)
        {
            return this.userRepo.GetById(id);
        }
    }
}
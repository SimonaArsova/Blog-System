using BlogSystem.Data.Model;
using BlogSystem.Data.Repositories;
using BlogSystem.Data.SaveContext;
using BlogSystem.Services.Contracts;
using System;
using System.Linq;

namespace BlogSystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEfRepository<Category> categoryRepo;
        private readonly ISaveContext context;

        public CategoryService(IEfRepository<Category> categoryRepo, ISaveContext context)
        {
            this.categoryRepo = categoryRepo;
            this.context = context;
        }

        public Category GetById(string id)
        {
            return this.categoryRepo.GetById(new Guid(id));
        }

        public IQueryable<Category> GetAll()
        {
            return this.categoryRepo.All;
        }
    }
}

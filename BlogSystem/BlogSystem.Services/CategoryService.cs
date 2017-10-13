using BlogSystem.Data.Model;
using BlogSystem.Data.Repositories;
using BlogSystem.Data.SaveContext;
using BlogSystem.Services.Contracts;
using Providers.Contracts;
using System;
using System.Linq;

namespace BlogSystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEfRepository<Category> categoryRepo;
        private readonly ISaveContext context;
        private readonly IGuidProvider guidProvider;

        public CategoryService(IEfRepository<Category> categoryRepo, ISaveContext context, IGuidProvider guidProvider)
        {
            this.categoryRepo = categoryRepo;
            this.context = context;
            this.guidProvider = guidProvider;
        }

        public Category GetById(string id)
        {
            return this.categoryRepo.GetById(this.guidProvider.CreateGuidFromString(id));
        }

        public IQueryable<Category> GetAll()
        {
            return this.categoryRepo.All;
        }
    }
}

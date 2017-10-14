using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
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
            this.categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.guidProvider = guidProvider ?? throw new ArgumentNullException(nameof(guidProvider));
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

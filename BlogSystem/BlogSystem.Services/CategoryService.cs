using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using BlogSystem.Factories;
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
        private readonly ICategoryFactory categoryFactory;

        public CategoryService(IEfRepository<Category> categoryRepo, ISaveContext context, ICategoryFactory categoryFactory, IGuidProvider guidProvider)
        {
            this.categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.categoryFactory = categoryFactory ?? throw new ArgumentNullException(nameof(categoryFactory));
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

        public void Create(string name)
        {
            Category category = this.categoryFactory.CreateCategory(name);
            this.categoryRepo.Add(category);

            context.SaveChanges();
        }
    }
}

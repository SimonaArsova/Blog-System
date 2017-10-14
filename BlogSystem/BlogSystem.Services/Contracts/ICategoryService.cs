using BlogSystem.Data.Model;
using System.Linq;

namespace BlogSystem.Services.Contracts
{
    public interface ICategoryService
    {
        Category GetById(string id);

        IQueryable<Category> GetAll();

        void Create(string name);
    }
}

using BlogSystem.Data.Model.Contracts;
using System.Linq;

namespace BlogSystem.Data.Repositories
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> Deleted { get; }
        IQueryable<T> AllIncludingDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Restore(T entity);
        void Update(T entity);
        T GetById(object id);
    }
}
using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model.Contracts;
using Providers.Contracts;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BlogSystem.Data
{
    public class EfRepository<T> : IEfRepository<T>
        where T : class, IDeletable
    {
        private readonly MsSqlDbContext context;
        private readonly IDateTimeProvider dateTimeProvider;

        public EfRepository(MsSqlDbContext context, IDateTimeProvider dateTimeProvider)
        {
            this.context = context;
            this.dateTimeProvider = dateTimeProvider;
        }

        public IQueryable<T> All
        {
            get
            {
                return this.context.Set<T>().Where(x => !x.IsDeleted);
            }
        }

        public IQueryable<T> AllIncludingDeleted
        {
            get
            {
                return this.context.Set<T>();
            }
        }

        public IQueryable<T> Deleted
        {
            get
            {
                return this.context.Set<T>().Where(x => x.IsDeleted);
            }
        }

        public T GetById(object id)
        {
            return this.context.Set<T>().Find(id);
        }


        public void Add(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.context.Set<T>().Add(entity);
            }
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = dateTimeProvider.GetCurrentDate();

            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Restore(T entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = dateTimeProvider.GetCurrentDate();

            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}

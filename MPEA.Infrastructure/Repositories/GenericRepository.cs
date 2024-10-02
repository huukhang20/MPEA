using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MPEA.Application.IRepository;

namespace MPEA.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        protected readonly DbSet<T> DbSet;

        public GenericRepository(AppDbContext context)
        {
            DbSet = context.Set<T>();
        }

        public virtual async Task AddAsync(T model)
        {
            await DbSet.AddAsync(model);
        }

        public virtual void AddAttach(T model)
        {
            DbSet.Attach(model).State = EntityState.Added;
        }

        public virtual void AddEntry(T model)
        {
            DbSet.Entry(model).State = EntityState.Added;
        }

        public virtual async Task AddRangeAsync(List<T> models)
        {
            await DbSet.AddRangeAsync(models);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<List<T>> GetAllAsync(
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> query = DbSet;
            if (include != null) query = include(query);
            return await query.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid? id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(T? model)
        {
            DbSet.Update(model);
        }

        public void UpdateRange(List<T> models)
        {
            DbSet.UpdateRange(models);
        }

        public async Task<T> CloneAsync(T model)
        {
            DbSet.Entry(model).State = EntityState.Detached;
            var values = DbSet.Entry(model).CurrentValues.Clone().ToObject() as T;
            return values;
        }

        public virtual async Task DeleteAsync(T model)
        {
            DbSet.Remove(model);
        }

        public virtual async Task DeleteRangeAsync(List<T> models)
        {
            DbSet.RemoveRange(models);
        }

        public async Task<bool> IsExistIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id) != null;
        }


        public virtual async Task<List<T>> GetByIdsAsync(List<Guid> ids)
        {
            return await DbSet.Where(e => ids.Contains((Guid)e.GetType().GetProperty("Id").GetValue(e, null)))
                .ToListAsync();
        }
    }
}

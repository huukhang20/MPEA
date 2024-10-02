using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPEA.Application.IRepository
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<T> CloneAsync(T model);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T?> GetByIdAsync(Guid? id);
        Task AddAsync(T model);
        void AddAttach(T model);
        void AddEntry(T model);
        void Update(T model);
        void UpdateRange(List<T> models);
        Task AddRangeAsync(List<T> models);
        Task DeleteAsync(T model);
        Task DeleteRangeAsync(List<T> models);
        Task<bool> IsExistIdAsync(Guid id);

        Task<List<T>> GetByIdsAsync(List<Guid> ids);
    }
}

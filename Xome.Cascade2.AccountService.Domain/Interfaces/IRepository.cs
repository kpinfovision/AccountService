using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Entities.Pagination;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> ExistsAsync(Guid id);
        Task BulkAddAsync(List<T> entities);

        Task<Xome.Cascade2.AccountService.Domain.Entities.PagedResult<T>> GetAsync(PagedRequest parameters, Func<IQueryable<T>, IQueryable<T>>? include = null);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Entities.Pagination;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;
using System.Linq.Dynamic.Core;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int Id)
        {
            var delEntity = await _dbContext.Set<T>().FindAsync(Id);
            if (delEntity != null)
            {
                _dbContext.Set<T>().Remove(delEntity);
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        public async Task BulkAddAsync(List<T> entities)
        {
            _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Xome.Cascade2.AccountService.Domain.Entities.PagedResult<T>> GetAsync(PagedRequest parameters,Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            var query = _dbSet.AsQueryable();

            // Optional include (e.g., p => p.Include(x => x.Category))
            if (include != null)
                query = include(query);

            // Filtering
            if (parameters.Filters != null)
            {
                foreach (var filter in parameters.Filters)
                {
                    string key = filter.Key;   // e.g., "Category.Name"
                    string value = filter.Value;

                    if (!string.IsNullOrEmpty(value))
                    {
                        query = query.Where($"{key}.Contains(@0)", value);
                    }
                }
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(parameters.SortColumn))
            {
                var sortOrder = parameters.SortDescending ? "descending" : "ascending";
                var orderExpression = $"{parameters.SortColumn} {sortOrder}";
                query = query.OrderBy(orderExpression);
            }

            // Pagination
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return new Xome.Cascade2.AccountService.Domain.Entities.PagedResult<T> { Items = items, TotalCount = totalCount };
        }
    }
}


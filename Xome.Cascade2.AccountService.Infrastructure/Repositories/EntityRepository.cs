using Xome.Cascade2.AccountService.Application.CommonExtensions;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckDuplicateAsync(string propertyName, object value)
        {
            return await _context.IsDuplicateAsync<T>(propertyName, value);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class TaxIDTypesRepository : ITaxIDTypesRepository
    {
        private readonly AppDbContext _context;
        public TaxIDTypesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaxIDTypes>> GetTaxIDTypes()
        {
            return await _context.TaxIDTypes.ToArrayAsync();
        }

        public Task<TaxIDTypes> GetTaxIDTypesByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

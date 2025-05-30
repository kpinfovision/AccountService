using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class CompanyTypeRepository : ICompanyTypeRepository
    {
        private readonly AppDbContext _context;
        public CompanyTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyTypes>> GetAllCompanyTypes()
        {
            return await _context.CompanyTypes.ToArrayAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;
        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task DeleteCompany(int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }
        }

        public async Task<IEnumerable<Company>> GetAllCompany()
        {
            return await _context.Companies.ToArrayAsync();
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            var company = _context.Companies.FirstOrDefault(a => a.CompanyId == companyId) ?? new Company();
            return company;
        }

        public async Task UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
        }
    }
}

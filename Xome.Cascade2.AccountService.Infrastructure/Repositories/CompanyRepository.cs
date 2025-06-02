using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public async Task BulkInsertCompany(IEnumerable<Company> companies)
        {
            await _context.Companies.AddRangeAsync(companies);
        }

        public async Task DeleteCompany(int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }
        }

        public async Task<IEnumerable<Company>> GetCompanies()
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

    public class CompanyStatesServedRepository : ICompanyStatesServedRepository
    {
        private readonly AppDbContext _context;
        public CompanyStatesServedRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanyStatesServed(CompanyStatesServed companyStatesServed)
        {
            await _context.companyStatesServed.AddAsync(companyStatesServed);
        }

        public async Task BulkInsertCompanyStatesServed(IEnumerable<CompanyStatesServed> companyStatesServed)
        {
            await _context.companyStatesServed.AddRangeAsync(companyStatesServed);
        }

        public Task DeleteCompanyStatesServed(int companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompanyStatesServed>> GetCompanyStatesServed()
        {
            return await _context.companyStatesServed.ToArrayAsync();
        }

        public async Task<CompanyStatesServed> GetCompanyStatesServedById(int companyId)
        {
            var companyStatesServed = _context.companyStatesServed.FirstOrDefault(a => a.CompanyId == companyId) ?? new CompanyStatesServed();
            return companyStatesServed;
        }
    }
}

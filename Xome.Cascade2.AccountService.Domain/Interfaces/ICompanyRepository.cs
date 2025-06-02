using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompanyById(int companyId);
        Task AddCompany(Company company);
        Task UpdateCompany(Company company);
        Task DeleteCompany(int companyId);
        Task BulkInsertCompany(IEnumerable<Company> company);
    }
    public interface ICompanyStatesServedRepository
    {
        Task<IEnumerable<CompanyStatesServed>> GetCompanyStatesServed();
        Task<CompanyStatesServed> GetCompanyStatesServedById(int companyId);
        Task AddCompanyStatesServed(CompanyStatesServed companyStatesServed);
        Task DeleteCompanyStatesServed(int companyId);
        Task BulkInsertCompanyStatesServed(IEnumerable<CompanyStatesServed> companyStatesServed);
    }
}

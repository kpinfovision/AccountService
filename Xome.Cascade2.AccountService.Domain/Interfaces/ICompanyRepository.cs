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
        Task<IEnumerable<Company>> GetAllCompany();
        Task<Company> GetCompanyById(int companyId);
        Task AddCompany(Company company);
        Task UpdateCompany(Company company);
        Task DeleteCompany(int companyId);
    }
}

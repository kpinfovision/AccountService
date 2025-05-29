using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllCompany()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyById(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}

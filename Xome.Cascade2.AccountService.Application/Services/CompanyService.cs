using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{

    public class CompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task AddCompany(Company company)
        {

            await _unitOfWork.Companies.AddCompany(company);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCompany(int id)
        {
            await _unitOfWork.Companies.DeleteCompany(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompany()
        {
            return await _unitOfWork.Companies.GetAllCompany();
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _unitOfWork.Companies.GetCompanyById(companyId);
        }

        public async Task UpdateCompany(Company company)
        {
            await _unitOfWork.Companies.UpdateCompany(company);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

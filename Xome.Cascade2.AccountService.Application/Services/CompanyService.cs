using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Xome.Cascade2.AccountService.Application.Services
{

    public class CompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString;
        private readonly IEntityRepository<Company> _entityRepository;

        public CompanyService(IUnitOfWork unitOfWork, IEntityRepository<Company> entityRepository)
        {
            _unitOfWork = unitOfWork;   
            _entityRepository = entityRepository;
        }
        /// we can remove it in future if not required
        public async Task AddCompany(Company company)
        {
            bool isDuplicateCompanyName = await _entityRepository.CheckDuplicateAsync("CompanyName", company.CompanyName);
            bool isDuplicateLegalEntityName = await _entityRepository.CheckDuplicateAsync("LegalEntityName", company.LegalEntityName);
            bool isDuplicateTaxId = await _entityRepository.CheckDuplicateAsync("TaxID", company.TaxID);
            if (isDuplicateCompanyName)
            {
                Console.WriteLine("Duplicate CompanyName");
            }
            if (isDuplicateLegalEntityName)
            {
                Console.WriteLine("Duplicate LegalEntityName");
            }
            if (isDuplicateTaxId)
            {
                Console.WriteLine("Duplicate TaxId");
            }
            if (isDuplicateCompanyName || isDuplicateLegalEntityName || isDuplicateTaxId) {
                Console.WriteLine("Return Error: 422");
            } 
            else
            {
                await _unitOfWork.Companies.AddCompany(company);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task BulkInsertCompany(IEnumerable<Company> companies, bool isFileUpload = false)
        {
            List<Company> validatedCompanies = new List<Company>();
            if (isFileUpload)
            {
                return;
            } else
            {
                foreach (var company in companies)
                {
                    bool isDuplicateCompanyName = await _entityRepository.CheckDuplicateAsync("CompanyName", company.CompanyName);
                    bool isDuplicateLegalEntityName = await _entityRepository.CheckDuplicateAsync("LegalEntityName", company.LegalEntityName);
                    bool isDuplicateTaxId = await _entityRepository.CheckDuplicateAsync("TaxID", company.TaxID);
                    if (isDuplicateCompanyName)
                    {
                        Console.WriteLine("Duplicate CompanyName");
                    }
                    if (isDuplicateLegalEntityName)
                    {
                        Console.WriteLine("Duplicate LegalEntityName");
                    }
                    if (isDuplicateTaxId)
                    {
                        Console.WriteLine("Duplicate TaxId");
                    }
                    if (isDuplicateCompanyName || isDuplicateLegalEntityName || isDuplicateTaxId)
                    {
                        Console.WriteLine("Return Error: 422");
                    }
                    else
                    {
                        validatedCompanies.Add(company);
                    }
                }

                if (validatedCompanies.Count > 0)
                {
                    await _unitOfWork.Companies.BulkInsertCompany(validatedCompanies);
                    await _unitOfWork.SaveChangesAsync();
                }
                else { 
                    Console.WriteLine(""); 
                }
            }

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

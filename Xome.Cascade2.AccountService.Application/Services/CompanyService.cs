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
            if (isDuplicateCompanyName || isDuplicateLegalEntityName || isDuplicateTaxId)
            {
                Console.WriteLine("Return Error: 422");
            }
            else
            {
                await _unitOfWork.Companies.AddCompany(company);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task BulkInsertCompanyAsync(IEnumerable<Company> companies, bool isFileUpload = false)
        {
            if (isFileUpload || companies == null || !companies.Any())
                return;

            var validatedCompanies = new List<Company>();

            foreach (var company in companies)
            {
                bool isDuplicateCompanyName = await _entityRepository.CheckDuplicateAsync("CompanyName", company.CompanyName);
                bool isDuplicateLegalEntityName = await _entityRepository.CheckDuplicateAsync("LegalEntityName", company.LegalEntityName);
                bool isDuplicateTaxId = await _entityRepository.CheckDuplicateAsync("TaxID", company.TaxID);

                if (isDuplicateCompanyName || isDuplicateLegalEntityName || isDuplicateTaxId)
                {
                    Console.WriteLine($"Duplicate record detected: {company.CompanyName}");
                    continue;
                }

                validatedCompanies.Add(company);
            }

            if (!validatedCompanies.Any())
            {
                Console.WriteLine("No valid companies to insert.");
                return;
            }

            // Begin Transaction
            using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _unitOfWork.Companies.BulkInsertCompany(validatedCompanies);
                await _unitOfWork.SaveChangesAsync();

                var companyStates = new List<CompanyStatesServed>();

                foreach (var company in validatedCompanies)
                {
                    companyStates.AddRange(company.StateServed.Select(stateId => new CompanyStatesServed
                    {
                        CompanyId = company.CompanyId,
                        StateId = stateId
                    }));
                }

                if (companyStates.Any())
                {
                    await _unitOfWork.CompanyStatesServed.BulkInsertCompanyStatesServed(companyStates);
                    await _unitOfWork.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error during bulk insert: {ex.Message}");
                throw; // Rethrow if req.
            }
        }

        public async Task DeleteCompany(int id)
        {
            await _unitOfWork.Companies.DeleteCompany(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _unitOfWork.Companies.GetCompanies();
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

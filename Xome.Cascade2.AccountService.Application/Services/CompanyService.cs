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
        private readonly IRepository<Company> _repository;

        public CompanyService(IUnitOfWork unitOfWork, IEntityRepository<Company> entityRepository, IRepository<Company> repository)
        {
            _unitOfWork = unitOfWork;
            _entityRepository = entityRepository;
            _repository = repository;
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
                await _unitOfWork.Repository<Company>().AddAsync(company);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task BulkInsertCompanyAsync(List<CompanySaveRequest> companies, bool isFileUpload = false)
        {
            if (isFileUpload || companies == null || !companies.Any())
                return;

            var validatedAddress = new List<Address>();

            foreach (var company in companies)
            {
                validatedAddress.Add(new Address()
                {
                    AddressId = 0, // company.AddressId,
                    Address1 = company.Address.AddressLine1,
                    Address2 = company.Address.AddressLine2,
                    City = company.Address.City,
                    State = company.Address.State,
                    Zip = company.Address.Zip,
                    Phone = company.Address.Phone,
                    Ext = company.Address.Ext,
                    // Fax = company.Address.Fax,
                    Active = true,
                    CreatedBy = 1, // need to change once token is implemented
                    CreatedOn = DateTime.UtcNow,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.UtcNow,
                });
            }            

            // Begin Transaction
            using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Insert Addresses First
                await _unitOfWork.Repository<Address>().BulkAddAsync(validatedAddress);
                await _unitOfWork.SaveChangesAsync();

                // Map AddressId back to companies (assumes same order)
                for (int i = 0; i < companies.Count; i++)
                {
                    companies[i].Address.AddressId = validatedAddress[i].AddressId;
                }

                var validatedCompanies = new List<Company>();

                foreach (var company in companies)
                {
                    bool isDuplicateCompanyName = await _entityRepository.CheckDuplicateAsync("CompanyName", company.CompanyName);
                    bool isDuplicateLegalEntityName = await _entityRepository.CheckDuplicateAsync("LegalEntityName", company.LegalEntityName);
                    bool isDuplicateTaxId = company.TaxIDType > 0 ? await _entityRepository.CheckDuplicateAsync("TaxID", company.TaxID) : false;

                    if (isDuplicateCompanyName || isDuplicateLegalEntityName || isDuplicateTaxId)
                    {
                        Console.WriteLine($"Duplicate record detected: {company.CompanyName}");
                        continue;
                    }

                    validatedCompanies.Add(new Company()
                    {
                        CompanyId = company.CompanyId,
                        CompanyName = company.CompanyName,
                        LegalEntityName = company.LegalEntityName,
                        TaxID = company.TaxID,
                        Abbreviation = company.Abbreviation,
                        AddressId = company.Address.AddressId,
                        CreatedBy = 1, // need to get it from token once implemented
                        CreatedOn = DateTime.UtcNow,
                        ModifiedBy = 1, // need to get it from token once implemented
                        ModifiedDate = DateTime.UtcNow,
                    });
                }

                if (!validatedCompanies.Any())
                {
                    Console.WriteLine("No valid companies to insert.");
                    return;
                }

                await _unitOfWork.Repository<Company>().BulkAddAsync(validatedCompanies);
                await _unitOfWork.SaveChangesAsync();

                if (transaction != null)
                    await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    await transaction.RollbackAsync();
                Console.WriteLine($"Error during bulk insert: {ex.Message}");
                throw; // Rethrow if req.
            }
        }

        public async Task DeleteCompany(int id)
        {
            var company = await _unitOfWork.Repository<Company>().GetByIdAsync(id);
            if (company != null)
            {
                await _unitOfWork.Repository<Company>().DeleteAsync(company);
                await _unitOfWork.SaveChangesAsync();
                //await _unitOfWork.Companies.DeleteCompany(id);
            }
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _unitOfWork.Repository<Company>().ListAllAsync();
           // return await _unitOfWork.Companies.GetCompanies();
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _unitOfWork.Repository<Company>().GetByIdAsync(companyId);
           // return await _unitOfWork.Companies.GetCompanyById(companyId);
        }

        public async Task UpdateCompany(Company company)
        {
            await _unitOfWork.Repository<Company>().UpdateAsync(company);
           // await _unitOfWork.Companies.UpdateCompany(company);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

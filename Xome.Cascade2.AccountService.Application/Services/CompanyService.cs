using Microsoft.Azure.Amqp.Framing;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

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

            var validatedAddress = new List<Xome.Cascade2.AccountService.Domain.Entities.Address>();

            foreach (var company in companies)
            {
                validatedAddress.Add(new Xome.Cascade2.AccountService.Domain.Entities.Address()
                {
                    AddressId = 0, // company.AddressId,
                    Address1 = company.Address.AddressLine1,
                    Address2 = company.Address.AddressLine2,
                    City = company.Address.City,
                    State = company.Address.State,
                    Zip = company.Address.Zip,
                    Phone = company.Address.Phone,
                    Ext = company.Address.Ext,
                    Fax = company.Address.Fax,
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
                await _unitOfWork.Repository<Xome.Cascade2.AccountService.Domain.Entities.Address>().BulkAddAsync(validatedAddress);
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
                        Status = company.Status,
                        //Address = string.Concat(company.Address.AddressLine1, company.Address.AddressLine2, company.Address.City, company.Address.State, company.Address.Zip),
                        //City = company.Address.City,
                        //State = company.Address.State,
                        //Zip = company.Address.Zip,
                        //DisplayName = company.DisplayName,
                        //StateServed = company.StateServed,

                    });
                }

                if (!validatedCompanies.Any())
                {
                    Console.WriteLine("No valid companies to insert.");
                    return;
                }

                await _unitOfWork.Repository<Company>().BulkAddAsync(validatedCompanies);
                await _unitOfWork.SaveChangesAsync();

                var companyStates = new List<CompanyStatesServed>();

                foreach (var company in validatedCompanies)
                {
                    //companyStates.AddRange(company.StateServed.Select(stateId => new CompanyStatesServed
                    //{
                    //    CompanyId = company.CompanyId,
                    //    StateId = stateId
                    //}));

                    //}

                    if (companyStates.Any())
                    {
                        await _unitOfWork.Repository<CompanyStatesServed>().BulkAddAsync(companyStates.ToList());
                        // await _unitOfWork.CompanyStatesServed.BulkInsertCompanyStatesServed(companyStates);
                        await _unitOfWork.SaveChangesAsync();
                    }

                    if (transaction != null)
                        await transaction.CommitAsync();
                }
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

        public async Task<CompanySearchResponse> GetCompanyByCompanyId(int companyId)
        {
            var company = await _unitOfWork.Repository<Company>().GetByIdAsync(companyId);
            var address = company != null ? await _unitOfWork.Repository<Xome.Cascade2.AccountService.Domain.Entities.Address>().GetByIdAsync(company.AddressId) : new Xome.Cascade2.AccountService.Domain.Entities.Address();
            var allStates = await _unitOfWork.Repository<States>().ListAllAsync();

            return new CompanySearchResponse()
            {
                CompanyName = company.CompanyName,
                Abbreviation = company.Abbreviation,
                LegalEntityName = company.LegalEntityName,
                DisplayName = string.Empty,
                Active = company.Status,
                Status = company.Status ? "Active" : "InActive",
                TaxId = company.TaxID,
                TaxIdType = string.Empty, // will assign once master data is available
                AddressId = company.AddressId,
                AddressLine1 = address != null ? address.Address1 : string.Empty,
                AddressLine2 = address != null ? address.Address2 : string.Empty,
                City = address != null ? address.City : string.Empty,
                State = allStates.FirstOrDefault(s => s.StateCode.ToLower() == address.State.ToLower())?.StateName,
                StateCd = address.State,
                Zip = address != null ? address.Zip : string.Empty,
                TaxIdTypeId = 0,
            };
        }

        public async Task<List<CompanySearchResponse>> GetFilteredCompanies(CompanySearchRequest parameters)
        {
            var companySearchList = new List<CompanySearchResponse>();

            //if (parameters.CompanyTypes.Any(ct => ct == (int)CompanyType.ASSETMANAGEMENTCO))
            //{
            //    var companies = await _unitOfWork.Repository<Company>().ListAllAsync();

            //}
           // var companies = await _unitOfWork.Repository<Company>().ListAllAsync();

            var pagedResult =  await _unitOfWork.Repository<Company>().GetAsync(parameters.SortFilters);
            if (pagedResult.Items.Any())
            {
                var result = pagedResult.Items.Where(i => i.Status == parameters.Status).ToList();

                var allStates = await _unitOfWork.Repository<States>().ListAllAsync();

                foreach (var company in result)
                {
                    var address = company != null ? await _unitOfWork.Repository<Xome.Cascade2.AccountService.Domain.Entities.Address>().GetByIdAsync(company.AddressId) : new Xome.Cascade2.AccountService.Domain.Entities.Address();

                    companySearchList.Add(new CompanySearchResponse()
                    {
                        CompanyName = company.CompanyName,
                        Abbreviation = company.Abbreviation,
                        LegalEntityName = company.LegalEntityName,
                        DisplayName = string.Empty,
                        Active = company.Status,
                        Status = company.Status ? "Active" : "InActive",
                        TaxId = company.TaxID,
                        TaxIdType = string.Empty, // will assign once master data is available
                        AddressId = company.AddressId,
                        AddressLine1 = address != null ? address.Address1 : string.Empty,
                        AddressLine2 = address != null ? address.Address2 : string.Empty,
                        City = address != null ? address.City : string.Empty,
                        State = allStates.FirstOrDefault(s => s.StateCode.ToLower() == address.State.ToLower())?.StateName,
                        StateCd = address.State,
                        Zip = address != null ? address.Zip : string.Empty,
                        TaxIdTypeId = 0,
                    });
                }
            }

            return companySearchList;
        }
    }
}

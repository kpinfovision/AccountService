using Microsoft.Azure.Amqp.Framing;
using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.SharedUtilities.ResponseModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Address = Xome.Cascade2.AccountService.Domain.Entities.Address;

namespace Xome.Cascade2.AccountService.Application.Services
{

    public class CompanyService : BaseService<CompanyService>
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
            var validations = new List<ValidationInfo>();

            if (isDuplicateCompanyName)
            {
                validations.Add(new ValidationInfo($"Duplicate CompanyName", BaseStatusCodes.Common.CustomMessage, field: "CompanyName"));
                // Console.WriteLine("Duplicate CompanyName");

            }
            if (isDuplicateLegalEntityName)
            {
                validations.Add(new ValidationInfo($"Duplicate LegalEntityName", BaseStatusCodes.Common.CustomMessage, field: "LegalEntityName"));
                // Console.WriteLine("Duplicate LegalEntityName");
            }
            if (isDuplicateTaxId)
            {
                validations.Add(new ValidationInfo($"Duplicate TaxId", BaseStatusCodes.Common.CustomMessage, field: "TaxId"));
                // Console.WriteLine("Duplicate TaxId");
            }
            if (isDuplicateCompanyName || isDuplicateLegalEntityName || isDuplicateTaxId)
            {
                ResponseEnvelope = new ResponseEnvelope()
                {
                    ValidationCollection = validations,
                };
                Console.WriteLine("Return Error: 422");
            }
            else
            {
                await _unitOfWork.Repository<Company>().AddAsync(company);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<List<CompanySaveResponse>> BulkInsertCompanyAsync(List<CompanySaveRequest> companies, bool isFileUpload = false)
        {
            var validations = new List<ValidationInfo>();
            var validatedCompanies = new List<Company>();

            if (isFileUpload || companies == null || !companies.Any())
            {
                validations.Add(new ValidationInfo($"No companies to upload", BaseStatusCodes.Common.CustomMessage, field: null));
                ResponseEnvelope = new ResponseEnvelope()
                {
                    ValidationCollection = validations,
                    MessageInfoCollection = new List<MessageInfo>
                        { new MessageInfo("Asset Management Company save failed See Validations for more details!", BaseStatusCodes.Common.CustomMessage, MessageType.ERROR) }

                };

                return new List<CompanySaveResponse>();
            }


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
                await _unitOfWork.Repository<Address>().BulkAddAsync(validatedAddress);
                await _unitOfWork.SaveChangesAsync();

                // Map AddressId back to companies (assumes same order)
                for (int i = 0; i < companies.Count; i++)
                {
                    companies[i].Address.AddressId = validatedAddress[i].AddressId;
                }

                foreach (var company in companies)
                {
                    if (company.CompanyName?.Length <= 0)
                    {
                        Console.WriteLine($"CompanyName Required");
                    }
                    bool isDuplicateCompanyName = await _entityRepository.CheckDuplicateAsync("CompanyName", company.CompanyName);
                    bool isDuplicateLegalEntityName = company.LegalEntityName?.Length > 0 ? await _entityRepository.CheckDuplicateAsync("LegalEntityName", company.LegalEntityName) : false;
                    bool isDuplicateTaxId = company.TaxIDType > 0 ? await _entityRepository.CheckDuplicateAsync("TaxID", company.TaxID) : false;

                    if (isDuplicateCompanyName)
                    {
                        validations.Add(new ValidationInfo($"Duplicate record detected: {company.CompanyName}", BaseStatusCodes.Common.CustomMessage, field: "CompanyName"));
                    }

                    if (isDuplicateLegalEntityName)
                    {
                        validations.Add(new ValidationInfo($"Duplicate record detected: {company.LegalEntityName}", BaseStatusCodes.Common.CustomMessage, field: "LegalEntityName"));
                    }

                    if (isDuplicateTaxId)
                    {
                        validations.Add(new ValidationInfo($"Duplicate record detected: {company.TaxID}", BaseStatusCodes.Common.CustomMessage, field: "TaxID"));

                    }
                    if (isDuplicateCompanyName || isDuplicateLegalEntityName || isDuplicateTaxId) {
                        continue;
                    }

                    validatedCompanies.Add(new Company()
                    {
                        CompanyId = company.CompanyId,
                        CompanyName = company.CompanyName,
                        LegalEntityName = company.LegalEntityName,
                        TaxID = company.TaxID,
                        Status = company.Status,
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
                    validations.Add(new ValidationInfo($"No valid companies to insert.", BaseStatusCodes.Common.CustomMessage, field: null));
                }

                if (validations.Any())
                {
                    ResponseEnvelope = new ResponseEnvelope()
                    {
                        MessageInfoCollection = new List<MessageInfo>
                        { new MessageInfo("Asset Management Company save failed See Validations for more details!", BaseStatusCodes.Common.CustomMessage, MessageType.ERROR) },
                        ValidationCollection = validations
                    };

                    return new List<CompanySaveResponse>();
                }

                await _unitOfWork.Repository<Company>().BulkAddAsync(validatedCompanies);
                await _unitOfWork.SaveChangesAsync();

                if (transaction != null)
                    await transaction.CommitAsync();



                var result = validatedCompanies.Select(x => new CompanySaveResponse { CompanyId = x.CompanyId, CompanyName = x.CompanyName }).ToList();
                return result;
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
            var companyTypes = await _unitOfWork.Repository<CompanyTypes>().ListAllAsync();

            return new CompanySearchResponse()
            {
                CompanyId = companyId,
                CompanyName = company.CompanyName,
                Abbreviation = company.Abbreviation,
                LegalEntityName = company.LegalEntityName,
                DisplayName = string.Empty,
                Active = company.Status,
                Status = company.Status ? "Active" : "InActive",
                TaxId = company.TaxID,
                TaxIdType = string.Empty, // will assign once master data is available
                CompanyTypeId = companyTypes.Any() ? companyTypes.FirstOrDefault(ct => ct.Active == true && ct.CompanyTypeId == 1).CompanyTypeId : 0,
                CompanyType = companyTypes.Any() ? companyTypes.FirstOrDefault(ct => ct.Active == true && ct.CompanyTypeId == 1).CompanyTypeName ?? string.Empty : string.Empty,

                Notes = company.Notes??string.Empty.Trim(),
                OutSourced = company.IsOutsourced,
                RemovedReasonId = 0,
                RemovedReason = string.Empty.Trim(),
                Address = new AddressResponse()
                {
                    AddressId = company.AddressId,
                    AddressLine1 = address != null ? address.Address1 : string.Empty,
                    AddressLine2 = address != null ? address.Address2 : string.Empty,
                    City = address != null ? address.City : string.Empty,
                    State = allStates.FirstOrDefault(s => s.StateCode.ToLower() == address.State.ToLower())?.StateName,
                    StateCd = address != null ? address.State : string.Empty,
                    Zip = address != null ? address.Zip : string.Empty,
                    Phone = address != null ? address.Phone : string.Empty,
                    Fax = address != null ? address.Fax : string.Empty,
                    Ext = address != null ? address.Ext : string.Empty,
                },
                TaxIdTypeId = 0,
            };
        }

        public async Task<List<CompanySearchResponse>> GetFilteredCompanies(CompanySearchRequest companySearchRequest)
        {
            var companySearchList = new List<CompanySearchResponse>();
            if (string.IsNullOrEmpty(companySearchRequest.SortFilters.SortColumn))
            {
                companySearchRequest.SortFilters.SortColumn = "CreatedOn";
                companySearchRequest.SortFilters.SortDescending = true;
            }
            var totalRows = 0;
            var companyTypes = await _unitOfWork.Repository<CompanyTypes>().ListAllAsync();
 
            var pagedResult = await _unitOfWork.Repository<Company>().GetAsync(companySearchRequest.SortFilters, q => q.Include(c => c.Address));
            if (pagedResult.Items.Any())
            {
                var result = pagedResult.Items.Where(i => i.Status == companySearchRequest.Status).ToList();
                totalRows = pagedResult.Items.Any() ? pagedResult.TotalCount : 0;

                var allStates = await _unitOfWork.Repository<States>().ListAllAsync();

                foreach (var company in result)
                {
                    var address = company != null ? await _unitOfWork.Repository<Xome.Cascade2.AccountService.Domain.Entities.Address>().GetByIdAsync(company.AddressId) : new Xome.Cascade2.AccountService.Domain.Entities.Address();

                    companySearchList.Add(new CompanySearchResponse()
                    {
                        CompanyId = company.CompanyId,
                        CompanyName = company.CompanyName,
                        Abbreviation = company.Abbreviation,
                        LegalEntityName = company.LegalEntityName,
                        DisplayName = string.Empty,
                        Active = company.Status,
                        Status = company.Status ? "Active" : "InActive",
                        TaxId = company.TaxID,
                        TaxIdType = string.Empty, // will assign once master data is available
                        CompanyTypeId = companyTypes.Any() ? companyTypes.FirstOrDefault(ct => ct.Active == true && ct.CompanyTypeId == 1).CompanyTypeId : 0,
                        CompanyType = companyTypes.Any() ? companyTypes.FirstOrDefault(ct => ct.Active == true && ct.CompanyTypeId == 1).CompanyTypeName??string.Empty : string.Empty,
                        Notes = company.Notes??string.Empty.Trim(),
                        OutSourced = company.IsOutsourced,
                        RemovedReasonId = 0,
                        RemovedReason = string.Empty.Trim(),
                        Address = new AddressResponse()
                        {
                            AddressId = company.AddressId,
                            AddressLine1 = address != null ? address.Address1 : string.Empty,
                            AddressLine2 = address != null ? address.Address2 : string.Empty,
                            City = address != null ? address.City : string.Empty,
                            State = allStates.FirstOrDefault(s => s.StateCode.ToLower() == address.State.ToLower())?.StateName,
                            StateCd = address != null ? address.State : string.Empty,
                            Zip = address != null ? address.Zip : string.Empty,
                            Phone = address != null ? address.Phone : string.Empty,
                            Fax = address != null ? address.Fax : string.Empty,
                            Ext = address != null ? address.Ext : string.Empty,
                        },
                        TaxIdTypeId = 0,
                    });
                }
            }

            this.PaginationEnvelope = new Pagination(companySearchRequest.SortFilters.PageNumber, companySearchRequest.SortFilters.PageSize, totalRows);

            return companySearchList;
        }
    }
}

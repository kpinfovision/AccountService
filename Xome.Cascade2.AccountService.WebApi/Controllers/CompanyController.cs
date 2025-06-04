using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Xml;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Repositories;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public readonly CompanyService _companyService;
        private readonly IEntityRepository<Company> _entityRepository;
        public CompanyController(CompanyService companyService, IEntityRepository<Company> entityRepository)
        {
            _companyService = companyService;
            _entityRepository = entityRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _companyService.GetCompanies();
        }

        [HttpGet("{companyId}")]
        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _companyService.GetCompanyById(companyId);
        }

        [HttpPost]
        public async Task<CompanySaveRequest> AddCompany(List<CompanySaveRequest> companyRequest) // List<CompanySaveRequest> companyRequest
        {
            // await _companyService.AddCompany(company);
            //companies.Add(companies);
            //return companies.First();
            List<CompanySaveRequest> companies = new List<CompanySaveRequest>();
            await _companyService.BulkInsertCompanyAsync(companyRequest, false);                     
            return companyRequest.ToList().First();
        }

        [HttpPut]
        public async Task UpdateCompany(Company company)
        {
            await _companyService.UpdateCompany(company);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCompany(int id)
        {
            await _companyService.DeleteCompany(id);
        }
    }
}

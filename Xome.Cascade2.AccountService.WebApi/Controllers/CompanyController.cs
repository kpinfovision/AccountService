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
        // private readonly IEntityRepository<Company> _entityRepository;
        public CompanyController(CompanyService companyService, IEntityRepository<Company> entityRepository)
        {
            _companyService = companyService;
            // _entityRepository = entityRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Company>> GetAllCompany()
        {
            return await _companyService.GetAllCompany();
        }

        [HttpGet("{companyId}")]
        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _companyService.GetCompanyById(companyId);
        }

        [HttpPost]
        public async Task<Company> AddCompany(Company company)
        {
            // await _companyService.AddCompany(company);
            List<Company> companies = new List<Company>();
            companies.Add(company);
            await _companyService.BulkInsertCompany(companies);
            return company;
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

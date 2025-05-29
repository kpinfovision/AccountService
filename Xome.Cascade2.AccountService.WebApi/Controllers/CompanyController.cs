using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
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
            await _companyService.AddCompany(company);
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

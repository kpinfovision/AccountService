using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxIDTypesController : ControllerBase
    {
        public readonly TaxIDTypesService _taxIDTypesService;
        public TaxIDTypesController(TaxIDTypesService taxIDTypesService)
        {
            _taxIDTypesService = taxIDTypesService;
        }
        [HttpGet]
        public async Task<IEnumerable<TaxIDTypes>> GetTaxIDTypes()
        {
            return await _taxIDTypesService.GetTaxIDTypes();
        }

        [HttpGet("{companyId}")]
        public async Task<TaxIDTypes> GetTaxIDTypesByUserId(int userId)
        {
            return await _taxIDTypesService.GetTaxIDTypesByUserId(userId);
        }
    }
}

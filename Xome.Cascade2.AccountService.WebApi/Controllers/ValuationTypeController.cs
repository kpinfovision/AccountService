using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuationTypeController : ControllerBase
    {
        public readonly ValuationTypeService _valuationTypeService;

        public ValuationTypeController(ValuationTypeService valuationTypeService)
        {
            _valuationTypeService = valuationTypeService;
        }
        [HttpGet]
        public async Task<IEnumerable<ValuationType>> GetAllValuationType()
        {
            return await _valuationTypeService.GetAllValuationTypesAsync();
        }
    }
}

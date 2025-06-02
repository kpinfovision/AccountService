using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        public readonly LookupService _lookupService;

        public CommonController(LookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("LookupData")]
        public async Task<dynamic> GetLookupData()
        {
            return await _lookupService.GetLookupData();
        }
    }
}

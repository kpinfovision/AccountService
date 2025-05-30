using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;
namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        public readonly FeatureService _featureService;
        public FeatureController(FeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet]
        public async Task<IEnumerable<Feature>> GetFeatures()
        {
            return await _featureService.GetFeatures();
        }

        [HttpGet("{companyId}")]
        public async Task<Feature> GetFeatureByUserId(int userId)
        {
            return await _featureService.GetFeatureByUserId(userId);
        }
    }
}

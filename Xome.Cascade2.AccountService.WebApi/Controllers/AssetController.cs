using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        public readonly AssetService _assetService;
        public readonly StateService _stateService;
        public readonly CompanyTypeService _companyTypeService;
        public AssetController(AssetService assetService, StateService stateService, CompanyTypeService companyTypeService)
        {
            _assetService = assetService;
            _stateService = stateService;
            _companyTypeService = companyTypeService;
        }
        [HttpGet]
        public async Task<IEnumerable<Asset>> GetAllAssets()
        {
            return await _assetService.GetAllAssets();
        }

        [HttpGet("{assetId}")]
        public async Task<Asset> GetAssetById(string assetId)
        {
            return await _assetService.GetAssetById(assetId);
        }

        [HttpPost]
        public async Task<Asset> AddAsset(Asset asset)
        {
            await _assetService.AddAsset(asset);
            return asset;
        }

        [HttpPut]
        public async Task UpdateAsset(Asset asset)
        {
            await _assetService.UpdateAsset(asset);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsset(int id)
        {
            await _assetService.DeleteAsset(id);
        }

        [HttpPut("UpdateAssetStatus")]
        public async Task<dynamic> UpdateAssetStatus(string assetId, string assetStatus, string processInstanceKey)
        {
            var asset = await _assetService.UpdateAssetStatus(assetId, assetStatus, processInstanceKey);
            return asset;
        }

        [HttpPost("TriggerExternalSystemEvent")]
        public async Task TriggerExternalSystemEvent(string assetId, string eventName)
        {
            await _assetService.TriggerExternalSystemEvent(assetId, eventName);
        }

        [HttpGet("States")]
        public async Task<IEnumerable<States>> GetAllStates()
        {
            return await _stateService.GetAllStates();
        }

        [HttpGet("CompanyTypes")]
        public async Task<IEnumerable<CompanyTypes>> GetAllCompanyTypes()
        {
            return await _companyTypeService.GetAllCompanyTypes();
        }
    }
}
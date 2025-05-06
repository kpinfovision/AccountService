using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> GetAllAssets();
        Task<Asset> GetAssetById(string assetId);
        Task AddAsset(Asset asset);
        Task UpdateAsset(Asset asset);
        Task DeleteAsset(int id);

    }
}
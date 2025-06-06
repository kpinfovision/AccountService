﻿using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class AssetRepository: IAssetRepository
    {
        private readonly AppDbContext _context;
        public AssetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsset(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
        }

        public async Task DeleteAsset(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset != null)
            {
                _context.Assets.Remove(asset);
            }
        }

        public async Task<IEnumerable<Asset>> GetAllAssets()
        {
            return await _context.Assets.ToArrayAsync();
        }

        public async Task<Asset> GetAssetById(string assetId)
        {
            var asset = _context.Assets.FirstOrDefault(a => a.AssetId == assetId) ?? new Asset();
            return asset;
        }

        public async Task UpdateAsset(Asset asset)
        {
            _context.Assets.Update(asset);
        }

        public async Task UpdateAssetStatus(string assetId, string assetStatus)
        {
            var asset =  _context.Assets.FirstOrDefault(a=> a.AssetId == assetId)??new Asset();
            if (asset != null)
            {
                asset.AssetStatus = assetStatus;
                _context.Assets.Update(asset);
            }
        }
    }
}
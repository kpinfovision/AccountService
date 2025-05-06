using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascase2.AccountService.Domain.Entities;
using Xome.Cascase2.AccountService.Domain.Interfaces;

namespace Xome.Cascase2.AccountService.Infrastructure.Repositories
{
    public class LoadValuationRepository : ILoadValuationRepository
    {
        public Task<LoadValuation> GetXVMAsync()
        {
            return Task.FromResult(
                new LoadValuation { Id = 1, AssetId = "A7", ValuationEffectiveDate = "06/05/2024", AsIsValue = "$880580", ValuationType = "Automated Valuation Model" }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class SellerConfigService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellerConfigService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SellerConfig> GetSellerConfigAsync()
        {
            var sellerConfig = await _unitOfWork.SellerConfig.GetSellerConfigAsync();
            return sellerConfig;
        }

        public async Task<SellerConfig> ToggleSellerConfig()
        {
            var sellerConfig = await _unitOfWork.SellerConfig.ToggleSellerConfig();
            await _unitOfWork.SaveChangesAsync();

            return sellerConfig;
        }
    }
}

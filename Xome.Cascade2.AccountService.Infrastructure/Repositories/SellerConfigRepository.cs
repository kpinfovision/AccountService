using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class SellerConfigRepository: ISellerConfigRepository
    {

        private readonly AppDbContext _context;
        public SellerConfigRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SellerConfig> GetSellerConfigAsync()
        {
            return await _context.sellerConfigs.FirstOrDefaultAsync();
        }

        public async Task<SellerConfig> ToggleSellerConfig()
        {
            var sellerConfig = _context.sellerConfigs.FirstOrDefault();
            if (sellerConfig != null)
            {
                sellerConfig.Status = !sellerConfig.Status;
            }

            return await _context.sellerConfigs.FirstOrDefaultAsync();
        }
    }    
}

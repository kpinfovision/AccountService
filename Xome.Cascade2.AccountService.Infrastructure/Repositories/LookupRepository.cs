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
    public class LookupRepository : ILookupRepository
    {
        private readonly AppDbContext _context;
        public LookupRepository(AppDbContext context) 
        {
            _context = context;
        }


        public async Task<IEnumerable<RemovedReason>> GetRemovedReasonAsync()
        {
            return await _context.RemovedReason.ToListAsync();
        }

        public async Task<IEnumerable<Services>> GetServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<IEnumerable<CompanyTypes>> GetCompaniesTypes()
        {
            return await _context.CompanyTypes.ToArrayAsync();
        }

        public async Task<IEnumerable<States>> GetAllStates()
        {
            return await _context.States.ToArrayAsync();
        }
    }
}

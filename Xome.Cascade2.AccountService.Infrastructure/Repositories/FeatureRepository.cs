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
    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext _context;
        public FeatureRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Feature>> GetAllFeatures()
        {
            return await _context.Features.ToArrayAsync(); 
        }        

        public Task<Feature> GetFeatureByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

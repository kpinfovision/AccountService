using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;
        public StateRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<States>> GetAllStates()
        {
            return await _context.States.ToArrayAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Infrastructure.Data;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAddress(Address address)
        {            
            await _context.Address.AddAsync(address);
        }

        public async Task DeleteAddress(int addressId)
        {
            var companyAddress = await _context.Address.FindAsync(addressId);
            if (companyAddress != null)
            {
                _context.Address.Remove(companyAddress);
            }
        }

        public async Task<IEnumerable<Address>> GetAddress()
        {
            return await _context.Address.ToArrayAsync();
        }

        public async Task<Address> GetAddressByCompanyId(int addressId)
        {

            var address = _context.Address.FirstOrDefault(a => a.AddressTypeId == addressId) ?? new Address();
            return address;
        }

        public async Task UpdateAddress(Address address)
        {
            _context.Address.Update(address);
        }
    }
}

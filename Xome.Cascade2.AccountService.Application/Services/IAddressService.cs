using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAddress();
        Task<Address> GetAddressByCompanyId(int companyId);
        Task AddAddress(Address address);
        Task UpdateAddress(Address address);
        Task DeleteAddress(int companyId);
    }
}

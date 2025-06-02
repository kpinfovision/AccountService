using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class AddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAddress(Address address)
        {

            await _unitOfWork.Address.AddAddress(address);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAddress(int companyId)
        {
            await _unitOfWork.Address.DeleteAddress(companyId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await _unitOfWork.Address.GetAddress();
        }

        public async Task<Address> GetAddressByCompanyId(int companyId)
        {
            return await _unitOfWork.Address.GetAddressByCompanyId(companyId);
        }

        public async Task UpdateAddress(Address address)
        {
            await _unitOfWork.Address.UpdateAddress(address);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
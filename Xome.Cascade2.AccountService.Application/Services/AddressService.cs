using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Address = Xome.Cascade2.AccountService.Domain.Entities.Address;

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

            await _unitOfWork.Repository<Address>().AddAsync(address);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAddress(int addressId)
        {
            await _unitOfWork.Repository<Address>().DeleteAsync(addressId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await _unitOfWork.Repository<Address>().ListAllAsync();
        }

        public async Task<Address> GetAddressByCompanyId(int companyId)
        {
            return await _unitOfWork.Repository<Address>().GetByIdAsync(companyId);
        }
        public async Task<Address> GetAddressById(int addressId)
        {
            return await _unitOfWork.Repository<Address>().GetByIdAsync(addressId);
        }

        public async Task UpdateAddress(Address address)
        {
            await _unitOfWork.Repository<Address>().UpdateAsync(address);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
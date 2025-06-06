using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class LookupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LookupService(IUnitOfWork unitOfWork) { 

            _unitOfWork = unitOfWork;
        }

        public async Task<dynamic> GetLookupData()
        {
            var removedReasons = Array.Empty<string>(); // await this.GetRemovedReasonAsync();
            var services = await this.GetServicesAsync();
            var companyTypes = await this.GetCompaniesTypes();
            var states = await this.GetAllStates();
            var taxTypes = await this.GetAllTaxIDTypes();
            return new
            {
                removedReasons = removedReasons,
                services = services,
                companyTypes = companyTypes,
                states = states,
                TaxIDTypes = taxTypes,
            };
        }

        public async Task<IEnumerable<RemovedReason>> GetRemovedReasonAsync()
        {
            return await _unitOfWork.Lookup.GetRemovedReasonAsync();
        }

        public async Task<IEnumerable<Xome.Cascade2.AccountService.Domain.Entities.Services>> GetServicesAsync()
        {
            return await _unitOfWork.Lookup.GetServicesAsync();
        }

        public async Task<IEnumerable<CompanyTypes>> GetCompaniesTypes()
        {
            return await _unitOfWork.Lookup.GetCompaniesTypes();
        }

        public async Task<IEnumerable<States>> GetAllStates()
        {
            return await _unitOfWork.Lookup.GetAllStates();
        }
        public async Task<IEnumerable<TaxIDTypes>> GetAllTaxIDTypes()
        {
            return await _unitOfWork.Lookup.GetAllTaxTypes();
        }
    }
}

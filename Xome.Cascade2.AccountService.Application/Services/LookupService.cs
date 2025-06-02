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

        public async Task<IEnumerable<RemovedReason>> GetRemovedReasonAsync()
        {
            return await _unitOfWork.Lookup.GetRemovedReasonAsync();
        }

        public async Task<IEnumerable<Xome.Cascade2.AccountService.Domain.Entities.Services>> GetServicesAsync()
        {
            return await _unitOfWork.Lookup.GetServicesAsync();
        }


    }
}

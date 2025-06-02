using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface ILookupRepository
    {
        Task <IEnumerable<RemovedReason>> GetRemovedReasonAsync();
        Task<IEnumerable<Services>> GetServicesAsync();
        Task<IEnumerable<CompanyTypes>> GetCompaniesTypes();
        Task<IEnumerable<States>> GetAllStates();
    }
}

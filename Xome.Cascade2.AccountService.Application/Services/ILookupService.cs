using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public interface ILookupService
    {
        Task<IEnumerable<RemovedReason>> GetRemovedReasonAsync();
        Task<IEnumerable<Xome.Cascade2.AccountService.Domain.Entities.Services>> GetServicesAsync();
    }
}

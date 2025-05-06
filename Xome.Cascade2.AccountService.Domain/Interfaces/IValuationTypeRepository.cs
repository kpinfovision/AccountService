using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface IValuationTypeRepository
    {
        Task<List<ValuationType>> GetAllValuationTypesAsync();
    }
}

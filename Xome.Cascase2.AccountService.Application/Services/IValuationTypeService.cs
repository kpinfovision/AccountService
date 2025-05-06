using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascase2.AccountService.Domain.Entities;

namespace Xome.Cascase2.AccountService.Application.Services
{
    public interface IValuationTypeService
    {
        Task<List<ValuationType>> GetAllValuationTypesAsync();
    }
}

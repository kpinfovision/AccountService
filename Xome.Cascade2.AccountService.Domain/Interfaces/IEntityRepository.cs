using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        Task<bool> CheckDuplicateAsync(string propertyName, object value);
    }
}

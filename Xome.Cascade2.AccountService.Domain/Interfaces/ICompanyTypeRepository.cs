using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface ICompanyTypeRepository
    {
        Task<IEnumerable<CompanyTypes>> GetAllCompanyTypes();
    }
}

using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public interface ICompanyTypeService
    {
        Task<IEnumerable<CompanyTypes>> GetAllCompanyTypes();
    }
}

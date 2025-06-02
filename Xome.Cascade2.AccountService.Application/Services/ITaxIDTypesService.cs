using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public interface ITaxIDTypesService
    {
        Task<IEnumerable<TaxIDTypes>> GetTaxIDTypes();
        Task<TaxIDTypes> GetTaxIDTypesByUserId(int userId);
    }
}

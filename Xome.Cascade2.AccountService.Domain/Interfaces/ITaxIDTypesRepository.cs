using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface ITaxIDTypesRepository
    {
        Task<IEnumerable<TaxIDTypes>> GetTaxIDTypes();
        Task<TaxIDTypes> GetTaxIDTypesByUserId(int userId);
    }
}

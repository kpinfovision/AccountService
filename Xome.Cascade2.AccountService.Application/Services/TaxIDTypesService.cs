using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class TaxIDTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString;

        public TaxIDTypesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TaxIDTypes>> GetTaxIDTypes()
        {
            return await _unitOfWork.TaxIDTypes.GetTaxIDTypes();
        }

        public async Task<TaxIDTypes> GetTaxIDTypesByUserId(int userId)
        {
            return await _unitOfWork.TaxIDTypes.GetTaxIDTypesByUserId(userId);
        }
    }
}

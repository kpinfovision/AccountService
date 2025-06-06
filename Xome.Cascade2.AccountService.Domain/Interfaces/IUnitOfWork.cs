using Microsoft.EntityFrameworkCore.Storage;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        ILookupRepository Lookup { get; }
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();

        // IUserRepository Users { get; }
        // IAssetRepository Assets { get; }
        //ICompanyRepository Companies { get; }
        //ICompanyStatesServedRepository CompanyStatesServed { get; }
        // IFeatureRepository Features { get; }
        // ITaxIDTypesRepository TaxIDTypes { get; }
        // IAddressRepository Address { get; }
        //IValuationTypeRepository valuationTypes { get; }
        //ILoadValuationRepository LoadValuations { get; }
        //ISellerConfigRepository SellerConfig { get; }
    }
}

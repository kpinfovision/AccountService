using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IAssetRepository Assets { get; }
        ICompanyRepository Companies { get; }
        IFeatureRepository Features { get; }
        IValuationTypeRepository valuationTypes { get; }
        ILoadValuationRepository LoadValuations { get; }
        ISellerConfigRepository SellerConfig { get; }
        IStateRepository States { get; }
        ICompanyTypeRepository CompanyTypes { get; }
        ILookupRepository Lookup { get; }
        Task<int> SaveChangesAsync();
    }
}

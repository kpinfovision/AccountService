using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IAssetRepository Assets { get; }
        ICompanyRepository Companies { get; }
        IValuationTypeRepository valuationTypes { get; }
        ILoadValuationRepository LoadValuations { get; }
        ISellerConfigRepository SellerConfig { get; }
        Task<int> SaveChangesAsync();
    }
}

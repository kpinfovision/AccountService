using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUserRepository Users { get; }
        public IAssetRepository Assets { get; }
        public ICompanyRepository Companies { get; }
        public IFeatureRepository Features { get; }
        public ITaxIDTypesRepository TaxIDTypes { get; }
        public IValuationTypeRepository valuationTypes { get; }
        public ILoadValuationRepository LoadValuations { get; }
        public ISellerConfigRepository SellerConfig { get; }
        public ILookupRepository Lookup { get; }


        public UnitOfWork(
            AppDbContext context,
            IUserRepository userRepository,
            IAssetRepository assetRepository,
            ILoadValuationRepository loadValuationRepository,
            IValuationTypeRepository valuationTypesRepository,
            ISellerConfigRepository sellerConfigRepository,
            ICompanyRepository companyRepository,
            IFeatureRepository featureRepository,
            ILookupRepository lookup,
            ITaxIDTypesRepository taxIDTypesRepository
            )
        {
            _context = context;
            Users = userRepository;
            Assets = assetRepository;
            valuationTypes = valuationTypesRepository;
            LoadValuations = loadValuationRepository;
            SellerConfig = sellerConfigRepository;
            Companies = companyRepository;
            Features = featureRepository;
            Lookup = lookup;
            TaxIDTypes = taxIDTypesRepository;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

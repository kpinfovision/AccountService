using Microsoft.EntityFrameworkCore.Storage;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;
using Xome.Cascade2.AccountService.Infrastructure.Repositories;

namespace Xome.Cascade2.AccountService.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<string, object> _repositories = new();
        public ILookupRepository Lookup { get; }

        //public ITaxIDTypesRepository TaxIDTypes { get; }
        //public IUserRepository Users { get; }
        //public IAssetRepository Assets { get; }
        //public ICompanyRepository Companies { get; }
        //public ICompanyStatesServedRepository CompanyStatesServed { get; }
        // public IFeatureRepository Features { get; }
        // public IAddressRepository Address { get; }
        //public IValuationTypeRepository valuationTypes { get; }
        //public ILoadValuationRepository LoadValuations { get; }
        //public ISellerConfigRepository SellerConfig { get; }


        public UnitOfWork(
            AppDbContext context,
            ILookupRepository lookup
            // ITaxIDTypesRepository taxIDTypesRepository
            // IAddressRepository addressRepository
            // ICompanyStatesServedRepository companyStatesServedRepository,
            //ICompanyRepository companyRepository,
            //IUserRepository userRepository,
            //IAssetRepository assetRepository,
            //ILoadValuationRepository loadValuationRepository,
            //IValuationTypeRepository valuationTypesRepository,
            //ISellerConfigRepository sellerConfigRepository,
            // IFeatureRepository featureRepository,
            )
        {
            _context = context;
            Lookup = lookup;
            // TaxIDTypes = taxIDTypesRepository;
            // Address = addressRepository;
            //CompanyStatesServed = companyStatesServedRepository;
            //Companies = companyRepository;
            //Users = userRepository;
            //Assets = assetRepository;
            //valuationTypes = valuationTypesRepository;
            //LoadValuations = loadValuationRepository;
            //SellerConfig = sellerConfigRepository;
            // Features = featureRepository;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var typeName = typeof(T).Name;

            if (!_repositories.ContainsKey(typeName))
            {
                var repoInstance = new Repository<T>(_context);
                _repositories[typeName] = repoInstance;
            }

            return (IRepository<T>)_repositories[typeName];
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_context.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
            {
                return null; // No transaction for in-memory
            }
            return await _context.Database.BeginTransactionAsync();
        }
    }
}

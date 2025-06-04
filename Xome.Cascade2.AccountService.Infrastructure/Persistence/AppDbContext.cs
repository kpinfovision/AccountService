using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using Xome.Cascade2.AccountService.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Xome.Cascade2.AccountService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CompanyStatesServed> companyStatesServed { get; set; }

        public DbSet<ValuationType> ValuationTypes { get; set; }

        public DbSet<LoadValuation> LoadValuations { get; set; }

        public DbSet<ManualTask> ManualTasks => Set<ManualTask>();

        public DbSet<TaskFields> TaskFields => Set<TaskFields>();

        public DbSet<UserTaskFieldMapping> UserTaskFieldMappings => Set<UserTaskFieldMapping>();

        public DbSet<SellerConfig> sellerConfigs => Set<SellerConfig>();

        public DbSet<Feature> Features { get; set; }
        public DbSet<TaxIDTypes> TaxIDTypes { get; set; }
        public DbSet<CompanyTypes> CompanyTypes { get; set; }
        public DbSet<States> States { get; set; }

        public DbSet<RemovedReason> RemovedReason { get; set; }
        public DbSet<Services> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Sujata", LastName = "Telang", Email = "sujata.telang@infovision.com", Role = "Asset Manager" },
                new User { Id = 2, FirstName = "Kiran", LastName = "Patwardhan", Email = "kiran.patwardhan@infovision.com", Role = "Auction Manager" },
                new User { Id = 3, FirstName = "Sujit", LastName = "Mhetre", Email = "sujit.mhetre@infovision.com", Role = "Marketing Specialist" },
                new User { Id = 4, FirstName = "Tejas", LastName = "Deogadkar", Email = "tejas.deogadkar@infovision.com", Role = "Asset Manager" },
                new User { Id = 5, FirstName = "Dilipkumar", LastName = "Pottigari", Email = "dilipkumar.pottigari@infovision.com", Role = "Asset Manager" }
            );

            modelBuilder.Entity<ManualTask>().HasData(
                new ManualTask { Id = 1, TaskId = 1, TaskName = "MarketingRequestTask" },
                new ManualTask { Id = 2, TaskId = 2, TaskName = "LoadValuationTask" }
            );
            modelBuilder.Entity<TaskFields>().HasData(
                new TaskFields { Id = 1 , TaskId = 1, TaskMappingFields = ["valuationEffectiveDate", "valuationType", "valuationExpires", "inspectionType", "preparedBy", "company", "asIsValue", "repairedValue", "repairedEstimate", "condition", "comments"] },
                new TaskFields { Id = 2, TaskId = 2, TaskMappingFields = ["address1", "address2", "valuationExpires", "city", "state", "zipCode", "county", "apn", "bpoValue", "transactionSubType", "sellerCode", "sellerSubCode", "propertyType", "bedRooms", "fullBathrooms", "partialBathrooms", "emv"] }
            );
            modelBuilder.Entity<UserTaskFieldMapping>().HasData(
                new UserTaskFieldMapping { Id = 1, UserId = 4, TaskId = 1, AccessTaskFields = ["valuationEffectiveDate", "valuationType", "valuationExpires", "inspectionType", "preparedBy", "company", "asIsValue", "repairedValue", "repairedEstimate", "condition", "comments"] },
                new UserTaskFieldMapping { Id = 2, UserId = 4, TaskId = 2, AccessTaskFields = [""] }
            );
            modelBuilder.Entity<SellerConfig>().HasData(
                new SellerConfig { Id = 1, ConfigName = "FundsTracking", Status = true}
            );
            //modelBuilder.Entity<Services>(eb => {
            //    eb.HasNoKey();               
            //});
            modelBuilder.Entity<CompanyStatesServed>()
                   .HasKey(cs => new { cs.CompanyId, cs.StateId });

            //modelBuilder.Entity<CompanyTypes>().HasData(
            //    new CompanyTypes {Id = 1, CompanyTypeId = 1, CompanyTypeName = "XOME" }
            //);
            //modelBuilder.Entity<States>().HasData(
            //    new States {Id = 1, stateId = 1, stateName = "New York", StateCode = "NY" }
            //);
            //
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Latitude)
                      .HasPrecision(9, 6);

                entity.Property(e => e.Longitude)
                      .HasPrecision(9, 6);
            });
        }
    }
}

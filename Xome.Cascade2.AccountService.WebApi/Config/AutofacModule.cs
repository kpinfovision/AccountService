﻿using Autofac;
using LazyProxy.Autofac;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Repositories;
using Xome.Cascade2.AccountService.Infrastructure.UnitOfWork;

namespace Xome.Cascade2.AccountService.WebApi.Config
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLazy<IUserRepository, UserRepository>().InstancePerLifetimeScope();
            builder.RegisterLazy<IAssetRepository, AssetRepository>().InstancePerLifetimeScope();
            builder.RegisterLazy<IValuationTypeRepository, ValuationTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterLazy<ILoadValuationRepository, LoadValuationRepository>().InstancePerLifetimeScope();
            builder.RegisterLazy<ISellerConfigRepository, SellerConfigRepository>().InstancePerLifetimeScope();
            builder.RegisterLazy<IUnitOfWork, UnitOfWork>().InstancePerLifetimeScope();
            // builder.RegisterLazy<IUserService, UserService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

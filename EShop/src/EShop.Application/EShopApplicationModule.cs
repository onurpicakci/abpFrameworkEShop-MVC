using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.BlobStoring;
using EShop.Files;
using Volo.Abp.Caching;
using EShop.Baskets;
using Microsoft.Extensions.Caching.Distributed;
using System;

namespace EShop;

[DependsOn(
    typeof(EShopDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(EShopApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpCachingModule)
    )]
[DependsOn(typeof(AbpBlobStoringModule))]
    public class EShopApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EShopApplicationModule>();
        });

        ConfigureDistributedCache();
    }

    private void ConfigureDistributedCache()
    {
        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.CacheConfigurators.Add(cacheName =>
            {
                if (cacheName == CacheNameAttribute.GetCacheName(typeof(Basket)))
                {
                    return new DistributedCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromDays(7)
                    };
                }

                return null;
            });
        });
    }
}

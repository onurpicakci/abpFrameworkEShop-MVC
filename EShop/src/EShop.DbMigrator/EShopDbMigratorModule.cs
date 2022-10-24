using EShop.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace EShop.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EShopEntityFrameworkCoreModule),
    typeof(EShopApplicationContractsModule)
    )]
public class EShopDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}

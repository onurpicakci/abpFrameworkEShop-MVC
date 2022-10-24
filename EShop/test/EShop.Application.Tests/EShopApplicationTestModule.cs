using Volo.Abp.Modularity;

namespace EShop;

[DependsOn(
    typeof(EShopApplicationModule),
    typeof(EShopDomainTestModule)
    )]
public class EShopApplicationTestModule : AbpModule
{

}

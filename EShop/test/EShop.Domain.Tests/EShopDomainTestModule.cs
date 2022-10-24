using EShop.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EShop;

[DependsOn(
    typeof(EShopEntityFrameworkCoreTestModule)
    )]
public class EShopDomainTestModule : AbpModule
{

}

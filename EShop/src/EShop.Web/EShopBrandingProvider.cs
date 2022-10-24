using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EShop.Web;

[Dependency(ReplaceServices = true)]
public class EShopBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EShop";
}

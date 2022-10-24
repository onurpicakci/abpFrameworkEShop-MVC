using Volo.Abp.Settings;

namespace EShop.Settings;

public class EShopSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EShopSettings.MySetting1));
    }
}

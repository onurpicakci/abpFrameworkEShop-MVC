using EShop.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EShop.Permissions;

public class EShopPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var eShopGroup = context.AddGroup(EShopPermissions.GroupName, L("Permission:EShop"));
        var eShopPermission = eShopGroup.AddPermission(EShopPermissions.Products.Default, L("Permission:Product"));
        eShopPermission.AddChild(EShopPermissions.Products.Create, L("Permission:Product.Create"));
        eShopPermission.AddChild(EShopPermissions.Products.Edit, L("Permission:Product.Edit"));
        eShopPermission.AddChild(EShopPermissions.Products.Delete, L("Permission:Product.Delete"));


        var categoryPermission = eShopGroup.AddPermission(EShopPermissions.Categories.Default, L("Permission:Category"));
        categoryPermission.AddChild(EShopPermissions.Categories.Create, L("Permission:Category.Create"));
        categoryPermission.AddChild(EShopPermissions.Categories.Edit, L("Permission:Category.Edit"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EShopResource>(name);
    }
}

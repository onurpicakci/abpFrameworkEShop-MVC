using System.Threading.Tasks;
using EShop.Baskets;
using EShop.Localization;
using EShop.MultiTenancy;
using EShop.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace EShop.Web.Menus;

public class EShopMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<EShopResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                EShopMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )


        );

        var eShopMenu = new ApplicationMenuItem(
            "EShop",
            l["Menu:EShop"],
            icon: "fa fa-shopping-bag"
            );

        context.Menu.AddItem(eShopMenu);

        if (await context.IsGrantedAsync(EShopPermissions.Products.Default))
        {
            eShopMenu.AddItem(new ApplicationMenuItem(

                "EShop.Products",
                l["Menu:Products"],
                icon: "fa fa-product-hunt",
                url: "/Products"


                ));
        }

        var basketMenu = new ApplicationMenuItem(
                "Basket",
                l["Menu:Basket"],
                icon: "fa fa-shopping-basket",
                url: "/Baskets"

            );

        context.Menu.AddItem(basketMenu);
        if (await context.IsGrantedAsync(EShopPermissions.Categories.Default)) 
        {
            var categoryMenu = new ApplicationMenuItem(
              "Category",
              l["Menu:Category"],
              icon: "fa fa-cart-arrow-down",
              url: "/Categories"

          );
            context.Menu.AddItem(categoryMenu);
        }
      

        










        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}

using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EShop.Data;

/* This is used if database provider does't define
 * IEShopDbSchemaMigrator implementation.
 */
public class NullEShopDbSchemaMigrator : IEShopDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

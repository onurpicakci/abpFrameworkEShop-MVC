using System.Threading.Tasks;

namespace EShop.Data;

public interface IEShopDbSchemaMigrator
{
    Task MigrateAsync();
}

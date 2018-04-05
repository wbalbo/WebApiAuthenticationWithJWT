using System.Data.Entity;

namespace DataAccessAPI.Core
{
    public class Initializer : MigrateDatabaseToLatestVersion<ProductsContext, Configuration>
    {
    }
}
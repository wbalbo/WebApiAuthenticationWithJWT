using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessAPI.Core
{
    public class ProductUserStore : UserStore<IdentityUser>
    {
        public ProductUserStore() : base(new ProductsContext())
        {

        }
    }
}
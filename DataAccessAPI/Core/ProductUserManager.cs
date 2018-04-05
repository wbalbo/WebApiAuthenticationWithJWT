using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessAPI.Core
{
    public class ProductUserManager : UserManager<IdentityUser>
    {
        public ProductUserManager() : base(new ProductUserStore())
        {

        }
    }
}
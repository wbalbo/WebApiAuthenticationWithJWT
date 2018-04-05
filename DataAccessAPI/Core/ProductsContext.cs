using DataAccessAPI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DataAccessAPI.Core
{
    public class ProductsContext : IdentityDbContext
    {
        public DbSet<Products> Products { get; set; }
    }
}
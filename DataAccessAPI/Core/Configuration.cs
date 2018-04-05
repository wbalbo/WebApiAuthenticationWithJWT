using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessAPI.Core
{
    public class Configuration : DbMigrationsConfiguration<ProductsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ProductsContext context)
        {
            //Adiciona produtos fake pra teste
            context.Products.AddOrUpdate(new Models.Products { ProductID = 1, Name = "PS4", Description = "Playstation 4 Pro", Price = 1800 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 2, Name = "Xbox One", Description = "Xbox One X", Price = 2100 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 3, Name = "Switch", Description = "Nintendo Switch", Price = 1400 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 4, Name = "TP1", Description = "Test Product 1", Price = 49 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 5, Name = "TP2", Description = "Test Product 2", Price = 99 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 6, Name = "TP3", Description = "Test Product 3", Price = 149 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 7, Name = "TP4", Description = "Test Product 4", Price = 199 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 8, Name = "TP5", Description = "Test Product 5", Price = 249 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 9, Name = "TP6", Description = "Test Product 6", Price = 299 });
            context.Products.AddOrUpdate(new Models.Products { ProductID = 10, Name = "TP7", Description = "Test Product 7", Price = 349 });

            //Obtém os roles de administrador e usuário, se houver, caso não exista os cria
            string adminRoleId = !context.Roles.Any() ? context.Roles.Add(new IdentityRole("Administrator")).Id : context.Roles.First(c => c.Name == "Administrator").Id;
            string userRoleId = !context.Roles.Any() ? context.Roles.Add(new IdentityRole("User")).Id : context.Roles.First(c => c.Name == "User").Id;

            context.SaveChanges();

            //Se não existe os usuário os cria e já define e hasheia a senha
            if (!context.Users.Any())
            {
                var administrator = context.Users.Add(new IdentityUser("administrator") { Email = "admin@teste.com.br", EmailConfirmed = true });
                administrator.Roles.Add(new IdentityUserRole { RoleId = adminRoleId });

                var standardUser = context.Users.Add(new IdentityUser("wellingtonbalbo") { Email = "wellingtonbalbo@teste.com.br", EmailConfirmed = true });
                standardUser.Roles.Add(new IdentityUserRole { RoleId = userRoleId });

                context.SaveChanges();

                var store = new ProductUserStore();
                store.SetPasswordHashAsync(administrator, new ProductUserManager().PasswordHasher.HashPassword("administrator123"));
                store.SetPasswordHashAsync(standardUser, new ProductUserManager().PasswordHasher.HashPassword("user123"));
            }

            context.SaveChanges();
        }
    }
}
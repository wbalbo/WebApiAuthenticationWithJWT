using DataAccessAPI.Core;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace DataAccessAPI.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new ProductsContext())
            {
                return Ok(await context.Products.Include(x=> "Produto: " + x.Name + " Descrição: " + x.Description + "Preço: " + x.Price).ToListAsync());
            }
        }
    }
}

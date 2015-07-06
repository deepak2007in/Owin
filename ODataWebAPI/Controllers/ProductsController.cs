// http://localhost:53687/Products?$top=2
// http://localhost:53687/Products?$top=2&$filter=(Prize%20gt%2035)
// http://localhost:53687/Products?$top=2&$filter=(Prize%20gt%2035)&$orderby=Prize
namespace ODataWebAPI.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.OData;
    using ODataWebAPI.Models;

    public class ProductsController : ApiController
    {
        private ProductsContext db = new ProductsContext();

        private bool ProductExists(int key)
        {
            return db.Products.Any(p => p.Id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return db.Products;
        }

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            var result = db.Products.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            db.Products.Add(entity: product);
            await db.SaveChangesAsync();
            return CreatedAtRoute(routeName: "ODataRoute", routeValues: new { controller = "Products" }, content: product);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            var entity = await db.Products.FindAsync(key);
            if(entity == null)
            {
                return NotFound();
            }

            product.Patch(entity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!ProductExists(key: key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Content(statusCode: HttpStatusCode.OK, value: entity);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Product update)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            if(key != update.Id)
            {
                return BadRequest();
            }

            db.Entry(update).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key: key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Content(statusCode: HttpStatusCode.OK, value: update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await db.Products.FindAsync(keyValues: key);
            if(product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
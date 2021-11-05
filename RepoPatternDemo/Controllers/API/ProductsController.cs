using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Modules.Contracts;

namespace RepoPatternDemo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IConnectionOwner connectionOwner;
        private readonly DbOwner dbOwner;
        public ProductsController(
            IConnectionOwner connectionOwner,
            DbOwner dbOwner
        )
        {
            this.connectionOwner = connectionOwner;
            this.dbOwner = dbOwner;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Products.GetAll(conn);
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Products.GetByID(conn, id);
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Products.Add(conn, product);
            });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Products.Update(conn, product);
            });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Products.Delete(conn, id);
            });

            return Ok(result);
        }
    }
}

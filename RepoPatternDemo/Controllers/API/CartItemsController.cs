using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Modules.Contracts;

namespace RepoPatternDemo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : Controller
    {
        private readonly IConnectionOwner connectionOwner;
        private readonly DbOwner dbOwner;
        public CartItemsController(
            IConnectionOwner connectionOwner,
            DbOwner dbOwner
        )
        {
            this.connectionOwner = connectionOwner;
            this.dbOwner = dbOwner;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.CartItems.GetAll(conn);
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemByID(int id)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.CartItems.GetByID(conn, id);
            });

            return Ok(result);
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetCartItemByCustomerID(int id)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.CartItems.GetByCustomerID(conn, id);
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CartItem cartItem)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.CartItems.Add(conn, cartItem);
            });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartItem(CartItem cartItem)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.CartItems.Update(conn, cartItem);
            });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.CartItems.Delete(conn, id);
            });

            return Ok(result);
        }
    }
}

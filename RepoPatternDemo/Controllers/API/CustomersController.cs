using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Modules.Contracts;

namespace RepoPatternDemo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IConnectionOwner connectionOwner;
        private readonly DbOwner dbOwner;
        public CustomersController(
            IConnectionOwner connectionOwner,
            DbOwner dbOwner
        )
        {
            this.connectionOwner = connectionOwner;
            this.dbOwner = dbOwner;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Customers.GetAll(conn);
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByID(int id)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Customers.GetByID(conn, id);
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Customers.Add(conn, customer);
            });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Customers.Update(conn, customer);
            });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await connectionOwner.Use(conn =>
            {
                return dbOwner.Customers.Delete(conn, id);
            });

            return Ok(result);
        }
    }
}

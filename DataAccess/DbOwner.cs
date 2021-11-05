using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Contracts;

namespace DataAccess
{
    public class DbOwner
    {
        public readonly IRepository<Product> Products;
        public readonly IRepository<Customer> Customers;
        public readonly ICartItemsRepository CartItems;
        public DbOwner()
        {
            Products = new ProductsRepository();
            Customers = new CustomersRepository();
            CartItems = new CartItemsRepository();
        }
    }
}

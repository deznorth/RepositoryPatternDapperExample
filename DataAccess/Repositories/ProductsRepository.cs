using DataAccess.Constants;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class ProductsRepository : BaseRepository<Product>
    {
        public ProductsRepository() : base(DbTables.Get(nameof(Product))) { }
    }
}

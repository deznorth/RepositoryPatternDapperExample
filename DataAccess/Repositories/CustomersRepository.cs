using DataAccess.Constants;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>
    {
        public CustomersRepository() : base(DbTables.Get(nameof(Customer))) { }
    }
}

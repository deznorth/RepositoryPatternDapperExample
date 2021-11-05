using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Contracts
{
    public interface ICartItemsRepository : IRepository<CartItem>
    {
        Task<IReadOnlyList<CartItem>> GetByCustomerID(IDbConnection conn, int customerId);
    }
}

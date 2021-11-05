using DataAccess.Constants;
using DataAccess.Entities;
using DataAccess.Repositories.Contracts;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CartItemsRepository : BaseRepository<CartItem>, ICartItemsRepository
    {
        public CartItemsRepository() : base(DbTables.Get(nameof(CartItem))) { }

        public async override Task<int> Update(IDbConnection conn, CartItem item)
        {
            var query = $@"
                UPDATE {_tableName}
                SET [Quantity] = @Quantity
                WHERE ID=@ID
            ";

            return await conn.ExecuteAsync(query, item);
        }

        public async Task<IReadOnlyList<CartItem>> GetByCustomerID(IDbConnection conn, int customerId)
        {
            var query = @$"
                SELECT *
                FROM {_tableName} ci
                WHERE ci.[CustomerID] = @CustomerID
            ";

            return (await conn.QueryAsync<CartItem>(query, new { CustomerID = customerId })).ToList();
        }
    }
}

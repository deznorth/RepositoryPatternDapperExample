using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Constants
{
    public class DbTables
    {
        private static Dictionary<string, string> mappings = new Dictionary<string, string>
        {
            { nameof(Customer), "[dbo].[Customers]" },
            { nameof(Product), "[dbo].[Products]" },
            { nameof(CartItem), "[dbo].[CartItems]" }
        };

        public static string Get(string entity) => mappings[entity];
    }
}

using DataAccess.Modules.Contracts;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess.Modules
{
    public class ConnectionOwner : IConnectionOwner
    {
        private readonly string connectionString;

        public ConnectionOwner(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<TResult> Use<TResult>(Func<IDbConnection, Task<TResult>> func)
        {
            using (var cnxn = new SqlConnection(connectionString))
            {
                await cnxn.OpenAsync().ConfigureAwait(false);
                return await func(cnxn).ConfigureAwait(false);
            }
        }

        public async Task Use(Func<IDbConnection, Task> func)
        {
            using (var cnxn = new SqlConnection(connectionString))
            {
                await cnxn.OpenAsync().ConfigureAwait(false);
                await func(cnxn).ConfigureAwait(false);
            }
        }

        public async Task<TResult> UseTransaction<TResult>(Func<IDbConnection, IDbTransaction, Task<TResult>> func)
        {
            using (var cnxn = new SqlConnection(connectionString))
            {
                await cnxn.OpenAsync().ConfigureAwait(false);
                var transaction = cnxn.BeginTransaction();
                var result = await func(cnxn, transaction).ConfigureAwait(false);
                transaction.Dispose();
                return result;
            }
        }

        public async Task UseTransaction(Func<IDbConnection, IDbTransaction, Task> func)
        {
            using (var cnxn = new SqlConnection(connectionString))
            {
                await cnxn.OpenAsync().ConfigureAwait(false);
                var transaction = cnxn.BeginTransaction();
                await func(cnxn, transaction).ConfigureAwait(false);
                transaction.Dispose();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Infrastructure.Interface
{
    public interface IDatabaseManager
    {
        OdbcCommand CreateCommand(OdbcConnection connection);
        Task<List<T>> ExecuteReaderAllAsync<T>(OdbcCommand command);
        Task<T> ExecuteReaderAsync<T>(OdbcCommand command);
        object ExecuteScalar(OdbcCommand command);
        Task<int> ExecuteNonQueryAsync(OdbcCommand command);
    }
}

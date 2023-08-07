using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Infrastructure.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string connSystem, string commandText, List<OdbcParameter> parameters = null);
        Task<T> GetByIdAsync(string connSystem,  string commandText, List<OdbcParameter> parameters);
        Task<IEnumerable<Tx>> GetByQueryAllAsync<Tx>(string connSystem,  string commandText, List<OdbcParameter> parameters);
        Task<Tx> GetByQueryAsync<Tx>(string connSystem,  string commandText, List<OdbcParameter> parameters);
        string GetSingleId(string connSystem,  string commandText, List<OdbcParameter> parameters);
        string GetSingleName(string connSystem,  string commandText, List<OdbcParameter> parameters);
        int GetRowCount(string connSystem,  string commandText, List<OdbcParameter> parameters);
        Task<int> InsertAsync(T entity, string connSystem,  string commandText, OdbcTransaction sqlTransaction, List<OdbcParameter> parameters);
        Task<Tx> InsertAndGetIDAsync<Tx>(T entity, string connSystem,  string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters);
        Task<int> UpdateAsync(string connSystem,  string commandText, OdbcTransaction sqlTransaction, List<OdbcParameter> parameters);
        Task<int> DeleteAsync(string connSystem,  string commandText, OdbcTransaction sqlTransaction, List<OdbcParameter> parameters);
        bool IsExist(string connSystem, string commandText, List<OdbcParameter> parameters);
    }
}

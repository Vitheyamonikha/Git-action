using RestFulAPI_Legasuite.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestFulAPI_Legasuite.Common.Configurations;
using RestFulAPI_Legasuite.Common.Enums;
using RestFulAPI_Legasuite.Common.Model;
using System.Collections;

namespace RestFulAPI_Legasuite.Infrastructure.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {        
        private readonly OdbcConnection _eqHSIConnection;
        private readonly OdbcConnection _aqHSIConnection;
        private readonly OdbcConnection _eqARCConnection;
        private readonly OdbcConnection _aqARCConnection;
        protected readonly IUnitOfWork UnitOfWork;
        private readonly IDatabaseManager _dataBaseManager;

        protected GenericRepository(IUnitOfWork uow, IDatabaseManager dataBaseManager)
        {
            UnitOfWork = uow ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            
            _eqHSIConnection = UnitOfWork.DataContext.EQHSIConnection;
            _aqHSIConnection = UnitOfWork.DataContext.AQHSIConnection;
            _eqARCConnection = UnitOfWork.DataContext.EQARCConnection;
            _aqARCConnection = UnitOfWork.DataContext.EQARCConnection;            
            _dataBaseManager = dataBaseManager;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string connSystem,  string commandText, List<OdbcParameter> parameters = null)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                var items = await _dataBaseManager.ExecuteReaderAllAsync<T>(cmd);
                return items;
            }
        }

        public async Task<T> GetByIdAsync(string connSystem,  string commandText, List<OdbcParameter> parameters)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {                
                cmd.CommandText = commandText;
                // cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(parameters.ToArray());
                return await _dataBaseManager.ExecuteReaderAsync<T>(cmd);
            }
        }       

        public async Task<IEnumerable<Tx>> GetByQueryAllAsync<Tx>(string connSystem, string commandText, List<OdbcParameter> parameters)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                // cmd.CommandType = CommandType.StoredProcedure;               
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(parameters.ToArray());
                cmd.CommandTimeout = 300;
                return await _dataBaseManager.ExecuteReaderAllAsync<Tx>(cmd);
            }
        }

        public async Task<Tx> GetByQueryAsync<Tx>(string connSystem,  string commandText, List<OdbcParameter> parameters)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                
                cmd.CommandText = commandText;
                // cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(parameters.ToArray());
                return await _dataBaseManager.ExecuteReaderAsync<Tx>(cmd);
            }
        }

        public int GetRowCount(string connSystem,  string commandText, List<OdbcParameter> parameters)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {                
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters.ToArray());
                return (int)_dataBaseManager.ExecuteScalar(cmd);
            }
        }

        public string GetSingleId(string connSystem,  string commandText, List<OdbcParameter> parameters)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {                
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters.ToArray());
                return (string)_dataBaseManager.ExecuteScalar(cmd);
            }
        }

        public string GetSingleName(string connSystem,  string commandText, List<OdbcParameter> parameters)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {               
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(parameters.ToArray());
                return _dataBaseManager.ExecuteScalar(cmd).ToString();
            }
        }

        public async Task<int> InsertAsync(T entity, string connSystem,  string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters)
        {
            var i = 0;
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = OdbcTransaction;
                cmd.Parameters.AddRange(parameters.ToArray());
                i = await _dataBaseManager.ExecuteNonQueryAsync(cmd);
                return i;
            }
        }

        public async Task<Tx> InsertAndGetIDAsync<Tx>(T entity, string connSystem,  string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = OdbcTransaction;
                cmd.Parameters.AddRange(parameters.ToArray());
                return await _dataBaseManager.ExecuteReaderAsync<Tx>(cmd);
            }
        }

        public async Task<int> UpdateAsync(string connSystem,  string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters)
        {
            var i = 0;
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = OdbcTransaction;
                cmd.Parameters.AddRange(parameters.ToArray());
                i = await _dataBaseManager.ExecuteNonQueryAsync(cmd);
            }
            return i;
        }

        public async Task<int> DeleteAsync(string connSystem,  string commandText, OdbcTransaction OdbcTransaction, List<OdbcParameter> parameters)
        {
            var i = 0;
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
               
                cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = OdbcTransaction;
                cmd.Parameters.AddRange(parameters.ToArray());
                i = await _dataBaseManager.ExecuteNonQueryAsync(cmd);
            }
            return i;
        }

        public bool IsExist(string connSystem,  string commandText, List<OdbcParameter> parameters)
        {
            var _conn = GetConnectionString(connSystem);
            using (var cmd = _dataBaseManager.CreateCommand(_conn))
            {
                
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters.ToArray());
                return (bool)_dataBaseManager.ExecuteScalar(cmd);
            }
        }
        private OdbcConnection GetConnectionString(string connSystem)
        {
            switch (connSystem)
            {
                case DbConnections.EQ_HSI:
                    return _eqHSIConnection;
                case DbConnections.AQ_HSI:
                    return _aqHSIConnection;
                case DbConnections.EQ_ARC:
                    return _eqARCConnection;
                case DbConnections.AQ_ARC:
                    return _aqARCConnection;
            }
            return null;
        }      

    }
}

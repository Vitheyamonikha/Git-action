using Microsoft.Extensions.Options;
using NLog;
using RestFulAPI_Legasuite.Common.Configurations;
using RestFulAPI_Legasuite.Common.Converter;
using RestFulAPI_Legasuite.Infrastructure.Interface;
using System.Data;
using System.Data.Odbc;

namespace RestFulAPI_Legasuite.Infrastructure.Context
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IOptions<ConnectionStrings> _connectionStrings;
        private OdbcConnection _connection;
        private OdbcConnection _eqHSIConnection;
        private OdbcConnection _eqARCConnection;
        private OdbcConnection _aqHSIConnection;
        private OdbcConnection _aqARCConnection;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DatabaseContext(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public OdbcConnection EQHSIConnection
        {
            get
            {
                if (_eqHSIConnection == null)
                {
                    string variableName = "EQ_HSI";
                    string EQ_HSIConString = Environment.GetEnvironmentVariable(variableName);
                    string decryptedConString = Encryptor.DecryptString(EQ_HSIConString);
                    _eqHSIConnection = new OdbcConnection(decryptedConString);
                }
                if (_eqHSIConnection.State != ConnectionState.Open)
                {
                    logger.Info("_eqHSIConnection-------" + _eqHSIConnection.State);
                    _eqHSIConnection.Open();
                }
                return _eqHSIConnection;
            }
        }

        public OdbcConnection EQARCConnection
        {
            get
            {
                if (_eqARCConnection == null)
                {
                    string variableName = "EQ_ARC";
                    string EQ_ARCConString = Environment.GetEnvironmentVariable(variableName);
                    string decryptedConString = Encryptor.DecryptString(EQ_ARCConString);
                    _eqARCConnection = new OdbcConnection(decryptedConString);
                }
                if (_eqARCConnection.State != ConnectionState.Open)
                {
                    logger.Info("_eqARCConnection-------" + _eqARCConnection.State);
                    _eqARCConnection.Open();
                }
                return _eqARCConnection;
            }
        }
        public OdbcConnection AQHSIConnection
        {
            get
            {
                if (_aqHSIConnection == null)
                {
                    string variableName = "AQ_HSI";
                    string AQ_HSIConString = Environment.GetEnvironmentVariable(variableName);
                    string decryptedConString = Encryptor.DecryptString(AQ_HSIConString);
                    _aqHSIConnection = new OdbcConnection(decryptedConString);
                }
                if (_aqHSIConnection.State != ConnectionState.Open)
                {
                    logger.Info("_aqHSIConnection-------" + _aqHSIConnection.State);
                    _aqHSIConnection.Open();
                }
                return _aqHSIConnection;
            }
        }
        public OdbcConnection AQARCConnection
        {
            get
            {
                if (_aqARCConnection == null)
                {
                    string variableName = "AQ_ARC";
                    string AQ_ARCConString = Environment.GetEnvironmentVariable(variableName);
                    string decryptedConString = Encryptor.DecryptString(AQ_ARCConString);
                    _aqARCConnection = new OdbcConnection(decryptedConString);
                }
                if (_aqARCConnection.State != ConnectionState.Open)
                {
                    logger.Info("_aqARCConnection-------" + _aqARCConnection.State);
                    _aqARCConnection.Open();
                }
                return _aqARCConnection;
            }
        }

        public OdbcConnection Connection
        {
            get
            {
                return _connection;
            }
        }
        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();

            if (_eqHSIConnection != null && _eqHSIConnection.State == ConnectionState.Open)
                _eqHSIConnection.Close();

            if (_eqARCConnection != null && _eqARCConnection.State == ConnectionState.Open)
                _eqARCConnection.Close();

            if (_aqHSIConnection != null && _aqHSIConnection.State == ConnectionState.Open)
                _aqHSIConnection.Close();

            if (_aqARCConnection != null && _aqARCConnection.State == ConnectionState.Open)
                _aqARCConnection.Close();
        }
    }
}

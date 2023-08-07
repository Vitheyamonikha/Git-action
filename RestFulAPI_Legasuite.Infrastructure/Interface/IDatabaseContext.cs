using RestFulAPI_Legasuite.Common.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Infrastructure.Interface
{
    public interface IDatabaseContext
    {
        OdbcConnection Connection { get; }
         OdbcConnection EQHSIConnection { get; }
        OdbcConnection AQHSIConnection { get; }
        OdbcConnection EQARCConnection { get; }
        OdbcConnection AQARCConnection { get; }
       
        void Dispose();
    }
}

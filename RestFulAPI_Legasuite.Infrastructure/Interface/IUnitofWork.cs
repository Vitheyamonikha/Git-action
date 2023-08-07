using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        IDatabaseContext DataContext { get; }
        OdbcTransaction BeginTransaction();
        void Commit();
    }
}

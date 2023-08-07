using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Infrastructure.Interface
{
    public interface IDatabaseContextFactory
    {
        IDatabaseContext Context();

    }
}

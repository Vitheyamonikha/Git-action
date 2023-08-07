using RestFulAPI_Legasuite.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Common.Interface
{
    public interface IUpdatePassword
    {
        public void UpdateIisEnvironmentalVariable(UpdatePasswordInputs updatePasswordInputs);
    }
}

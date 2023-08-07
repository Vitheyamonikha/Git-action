using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Core.Entities
{
    public class ReceiptDetailsRequestCoreModel
    {
        public string receiptdoc { get; set; }
        public string receipttype { get; set; }
        public string customernumber { get; set; }
        public string Division { get; set; }
        
    }
}

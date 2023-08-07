using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Core.Entities
{
    public class ReceiptDetailsResponseCoreModel
    {       
        public string rpan8 { get; set; }
        public string Invoice_Number { get; set; }
        public string Doc_Type { get; set; }
        public string Suffix { get; set; }
        public string InvMatch_Amount { get; set; }
        public string Receipt_Date { get; set; }
        public string GL_Date { get; set; }
        public string Currency_Code { get; set; }
    }
}

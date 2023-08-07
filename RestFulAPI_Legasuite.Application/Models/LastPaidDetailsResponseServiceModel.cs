using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Application.Models
{
    public class LastPaidDetailsResponseServiceModel
    {        
        public string addressnumber { get; set; }
        public string credit_manager { get; set; }
        public string credit_manager_name { get; set; }
        public string credit_rep { get; set; }
        public string credit_rep_name { get; set; }
        public string receipt_date { get; set; }
        public string late_charge { get; set; }
        public string receipt_amount { get; set; }
        public string receipt_doc { get; set; }
        public string receipt_type { get; set; }
    }
}

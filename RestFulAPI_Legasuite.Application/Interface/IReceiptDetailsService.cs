using RestFulAPI_Legasuite.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Application.Interface
{
    public interface IReceiptDetailsService
    {
        Task<IEnumerable<ReceiptDetailsResponseServiceModel>> GetReceiptPaidDetailsByReceiptDocandReceiptTypeAsyncServiceMethod(ReceiptDetailsRequestServiceModel receiptDetailsRequestServiceModel);
    }
}

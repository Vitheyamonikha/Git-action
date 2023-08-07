﻿using RestFulAPI_Legasuite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Infrastructure.Interface
{
    public interface IReceiptDetailsRepository
    {
        Task<IEnumerable<ReceiptDetailsResponseCoreModel>> GetReceiptPaidDetailsByReceiptDocandReceiptTypeAsyncRepositoryMethod(ReceiptDetailsRequestCoreModel receiptDetailsRequestCoreModel,string lastpaiddateresult);
        string GetLastPaidDateByReceiptDocandReceiptTypeAsyncRepositoryMethod(ReceiptDetailsRequestCoreModel receiptDetailsRequestCoreModel);
    }
}

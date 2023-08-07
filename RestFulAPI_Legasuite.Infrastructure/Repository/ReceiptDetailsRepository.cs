using RestFulAPI_Legasuite.Common.Enums;
using RestFulAPI_Legasuite.Core.Entities;
using RestFulAPI_Legasuite.Infrastructure.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Infrastructure.Repository
{    
     public class ReceiptDetailsRepository : GenericRepository<ReceiptDetailsResponseCoreModel>, IReceiptDetailsRepository
    {
        public ReceiptDetailsRepository(IUnitOfWork unitOfWork, IDatabaseManager dataBaseManager) : base(unitOfWork, dataBaseManager) { }

        public async Task<IEnumerable<ReceiptDetailsResponseCoreModel>> GetReceiptPaidDetailsByReceiptDocandReceiptTypeAsyncRepositoryMethod(ReceiptDetailsRequestCoreModel receiptDetailsRequestCoreModel, string lastpaiddateresult)
        {
            var commandText = AccountsReceivableSQL.GetReceiptDetails;
            var division = receiptDetailsRequestCoreModel.Division;
            var DivConnection = "";
            if (division == "HSI")
            {               
                DivConnection = "EQ_HSI";
            }
            else if (division == "ARC")
            {
                DivConnection = "EQ_ARC";
            }
            var parameters = new List<OdbcParameter>
                {
                    new OdbcParameter {ParameterName = "@rpan8", Value= receiptDetailsRequestCoreModel.customernumber},
                    new OdbcParameter {ParameterName = "@rpdocm", Value= receiptDetailsRequestCoreModel.receiptdoc},
                    new OdbcParameter {ParameterName = "@rpdctm", Value= receiptDetailsRequestCoreModel.receipttype},
                    new OdbcParameter {ParameterName = "@rpdgj", Value= lastpaiddateresult}
                };
            var result = await GetByQueryAllAsync<ReceiptDetailsResponseCoreModel>(DivConnection, commandText, parameters);
            return result;
        }
        public  string GetLastPaidDateByReceiptDocandReceiptTypeAsyncRepositoryMethod(ReceiptDetailsRequestCoreModel receiptDetailsRequestCoreModel)
        {
            var commandText = AccountsReceivableSQL.GetLastPaidDate;
            var division = receiptDetailsRequestCoreModel.Division;
            var DivConnection = "";
            
            if (division == "HSI")
            {
                DivConnection = "EQ_HSI";
            }
            else if (division == "ARC")
            {
                DivConnection = "EQ_ARC";
            }
            var parameters = new List<OdbcParameter>
                {
                    new OdbcParameter {ParameterName = "@rpan8", Value= receiptDetailsRequestCoreModel.customernumber},
                    new OdbcParameter {ParameterName = "@rpdocm", Value= receiptDetailsRequestCoreModel.receiptdoc}
                };
            var result =  GetSingleName(DivConnection, commandText, parameters);
            return result;
        }
    }
}

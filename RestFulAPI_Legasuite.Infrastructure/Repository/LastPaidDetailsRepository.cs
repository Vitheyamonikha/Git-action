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
    public class LastPaidDetailsRepository : GenericRepository<LastPaidDetailsResponseCoreModel>, ILastPaidDetailsRepository
    {
        public LastPaidDetailsRepository(IUnitOfWork unitOfWork, IDatabaseManager dataBaseManager) : base(unitOfWork, dataBaseManager) { }

        public async Task<IEnumerable<LastPaidDetailsResponseCoreModel>> GetLastPaidDetailsByCustomerNumberAsyncRepositoryMethod(LastPaidDetailsRequestCoreModel lastPaidDetailsRequestCoreModel)
        {
            var commandText = AccountsReceivableSQL.GetLastPaidDetails;
            var division = lastPaidDetailsRequestCoreModel.Division;
            var DivConnection = "";
            if (division == "HSI") 
            {              
                
                DivConnection = "EQ_HSI";
            }
            if (division == "ARC")
            {            
               
                DivConnection = "EQ_ARC";
            }
            var parameters = new List<OdbcParameter>
                {
                    new OdbcParameter {ParameterName = "@rpan8", Value= lastPaidDetailsRequestCoreModel.CustomerNumber},
                    new OdbcParameter {ParameterName = "@rpan8", Value= lastPaidDetailsRequestCoreModel.CustomerNumber}
                };
            var result = await GetByQueryAllAsync<LastPaidDetailsResponseCoreModel>(DivConnection, commandText, parameters);
            return result;
        }
    }
}

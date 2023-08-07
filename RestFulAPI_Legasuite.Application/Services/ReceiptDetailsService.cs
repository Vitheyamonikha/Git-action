using AutoMapper;
using RestFulAPI_Legasuite.Application.Interface;
using RestFulAPI_Legasuite.Application.Models;
using RestFulAPI_Legasuite.Core.Entities;
using RestFulAPI_Legasuite.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Application.Services
{    
    public class ReceiptDetailsService : IReceiptDetailsService
    {
        private readonly IReceiptDetailsRepository _receiptdetailsRepository;
        private readonly IMapper _mapper;

        public ReceiptDetailsService(IReceiptDetailsRepository receiptdetailsRepository, IMapper mapper)
        {
            _receiptdetailsRepository = receiptdetailsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReceiptDetailsResponseServiceModel>> GetReceiptPaidDetailsByReceiptDocandReceiptTypeAsyncServiceMethod(ReceiptDetailsRequestServiceModel receiptDetailsRequestServiceModel)
        {
            
            var requestModel = _mapper.Map<ReceiptDetailsRequestCoreModel>(receiptDetailsRequestServiceModel);
            var lastpaiddateresult = _receiptdetailsRepository.GetLastPaidDateByReceiptDocandReceiptTypeAsyncRepositoryMethod(requestModel);
            
            if(!string.IsNullOrWhiteSpace(lastpaiddateresult))
            {
                string formattedDate = DateTime.Parse(lastpaiddateresult.ToString()).ToString("yyyy-MM-dd");
                var result = await _receiptdetailsRepository.GetReceiptPaidDetailsByReceiptDocandReceiptTypeAsyncRepositoryMethod(requestModel, formattedDate);
                var receiptdetails = _mapper.Map<IEnumerable<ReceiptDetailsResponseServiceModel>>(result);
                return receiptdetails;
            }
            else
            {
                return Enumerable.Empty<ReceiptDetailsResponseServiceModel>();
            }
           

        }
    }
}

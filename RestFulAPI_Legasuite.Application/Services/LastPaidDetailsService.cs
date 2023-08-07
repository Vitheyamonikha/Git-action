using AutoMapper;
using RestFulAPI_Legasuite.Application.Interface;
using RestFulAPI_Legasuite.Application.Models;
using RestFulAPI_Legasuite.Core.Entities;
using RestFulAPI_Legasuite.Infrastructure.Interface;
using RestFulAPI_Legasuite.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Application.Services
{    
    public class LastPaidDetailsService : ILastPaidDetailsService
    {
        private readonly ILastPaidDetailsRepository _lastPaidDetailsRepository;
        private readonly IMapper _mapper;

        public LastPaidDetailsService(ILastPaidDetailsRepository lastPaidDetailsRepository, IMapper mapper)
        {
            _lastPaidDetailsRepository = lastPaidDetailsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LastPaidDetailsResponseServiceModel>> GetLastPaidDetailsByCustomerNumberAsyncServiceMethod(LastPaidDetailsRequestServiceModel lastPaidDetailsRequestServiceModel)
        {
            var requestModel = _mapper.Map<LastPaidDetailsRequestCoreModel>(lastPaidDetailsRequestServiceModel);
            var result = await _lastPaidDetailsRepository.GetLastPaidDetailsByCustomerNumberAsyncRepositoryMethod(requestModel);
            var lastpaiddetails = _mapper.Map<IEnumerable<LastPaidDetailsResponseServiceModel>>(result);
            return lastpaiddetails;
        }
    }
}

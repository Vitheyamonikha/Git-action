using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NLog;
using RestFulAPI_Legasuite.Application.Interface;
using RestFulAPI_Legasuite.Application.Models;
using RestFulAPI_Legasuite.Models;
using System.Web.Http.Description;

namespace RestFulAPI_Legasuite.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LastPaidDetailsController : Controller
    {
        private readonly ILastPaidDetailsService _lastPaidDetailsService;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public LastPaidDetailsController(ILastPaidDetailsService lastPaidDetailsService, IMapper mapper)
        {
            _lastPaidDetailsService = lastPaidDetailsService;
            _mapper = mapper;
        }

        [EnableCors("CorsPolicy")]
        [HttpPut()]
        [Consumes("application/json")]
        [ResponseType(typeof(IEnumerable<LastPaidDetailsResponseModel>))]
        public async Task<IEnumerable<LastPaidDetailsResponseModel>> Get([FromBody] LastPaidDetailsRequestModel lastPaidDetailsResquestModel)
        {
            var requestModel = _mapper.Map<LastPaidDetailsRequestServiceModel>(lastPaidDetailsResquestModel);
            var result = await _lastPaidDetailsService.GetLastPaidDetailsByCustomerNumberAsyncServiceMethod(requestModel);
            var lastpaiddetails = _mapper.Map<IEnumerable<LastPaidDetailsResponseModel>>(result);
            return lastpaiddetails;
        }
    }
}

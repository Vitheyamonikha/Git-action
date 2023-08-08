using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestFulAPI_Legasuite.Application.Interface;
using RestFulAPI_Legasuite.Application.Models;
using RestFulAPI_Legasuite.Models;
using System.Web.Http.Description;

namespace RestFulAPI_Legasuite.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReceiptDetailsController : Controller
    {
        private readonly IReceiptDetailsService _receiptdetailsService;
        private readonly IMapper _mapper;
        public ReceiptDetailsController(IReceiptDetailsService receiptDetailsService, IMapper mapper)
        {
            _receiptdetailsService = receiptDetailsService;
            _mapper = mapper;
        }
        //GetByID
        [EnableCors("CorsPolicy")]
        [HttpPut()]
        [ResponseType(typeof(IEnumerable<ReceiptDetailsResponseModel>))]
        public async Task<IEnumerable<ReceiptDetailsResponseModel>> Get(ReceiptDetailsRequestModel receiptDetailsRequestModel)
        {
            var requestModel = _mapper.Map<ReceiptDetailsRequestServiceModel>(receiptDetailsRequestModel);
            var result = await _receiptdetailsService.GetReceiptPaidDetailsByReceiptDocandReceiptTypeAsyncServiceMethod(requestModel);
            var receiptdetails = _mapper.Map<IEnumerable<ReceiptDetailsResponseModel>>(result);
            return receiptdetails;

        }
    }
}

using AutoMapper;
using RestFulAPI_Legasuite.Application.Models;
using RestFulAPI_Legasuite.Models;

namespace RestFulAPI_Legasuite.Mapper
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {            
            CreateMap<LastPaidDetailsRequestServiceModel, LastPaidDetailsRequestModel>().ReverseMap();
            CreateMap<LastPaidDetailsResponseServiceModel, LastPaidDetailsResponseModel>().ReverseMap();
            CreateMap<ReceiptDetailsRequestServiceModel, ReceiptDetailsRequestModel>().ReverseMap();
            CreateMap<ReceiptDetailsResponseServiceModel, ReceiptDetailsResponseModel>().ReverseMap();
        }
    }
}

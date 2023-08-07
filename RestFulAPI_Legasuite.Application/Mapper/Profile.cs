using AutoMapper;
using RestFulAPI_Legasuite.Application.Interface;
using RestFulAPI_Legasuite.Application.Services;
using RestFulAPI_Legasuite.Core.Entities;
using RestFulAPI_Legasuite.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Application.Mapper
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {            
            CreateMap<LastPaidDetailsRequestCoreModel, LastPaidDetailsRequestServiceModel>().ReverseMap();
            CreateMap<LastPaidDetailsResponseCoreModel, LastPaidDetailsResponseServiceModel>().ReverseMap();
            CreateMap<ReceiptDetailsRequestCoreModel, ReceiptDetailsRequestServiceModel>().ReverseMap();
            CreateMap<ReceiptDetailsResponseCoreModel, ReceiptDetailsResponseServiceModel>().ReverseMap();
        }
    }
}

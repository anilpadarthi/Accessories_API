using AutoMapper;
using POS_Accessories.Models;

namespace POS_Accessories.Business.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductRequestModel>().ReverseMap();
            CreateMap<ProductPriceMap, ProductPriceRequestModel>().ReverseMap();
        }
    }
}

using AutoMapper;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Business.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductRequestModel>().ReverseMap();
            CreateMap<Category, CategoryRequestModel>().ReverseMap();   
            CreateMap<ProductPriceMap, ProductPriceRequestModel>().ReverseMap();
            CreateMap<OrderDetailsMap, OrderProductModel>().ReverseMap();
            CreateMap<Order, OrderDetailsModel>().ForMember(dest=>dest.Items,act=>act.MapFrom(src => src.OrderDetailsMaps)).ReverseMap();
        }
    }
}

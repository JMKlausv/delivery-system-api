using AutoMapper;
using delivery_system_api.Domain.Models;
using delivery_system_api.Extensions;
using delivery_system_api.Resources;

namespace delivery_system_api.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<UserCredentialResource, User>();
            CreateMap<CategoryResource,Category>();
            CreateMap<ProductResource, Product>();
            CreateMap<OrderAddressResource, OrderAddress>().ReverseMap();
            CreateMap<OrderProductItemResource, OrderProductItem>().ReverseMap();    
            // CreateMap<OrderResource, Order>().ReverseMap();
            CreateMap<OrderResource, SaveOrderResource>();
            CreateMap<SaveOrderResource,Order>();
            CreateMap<OrderProductItem, FetchOrdersProductItemResource>();
            CreateMap<Order, FetchOrdersResource>();
        }
    }
}

using AutoMapper;
using CloudsEcommerce.Models;
using Domain;

namespace CloudsEcommerce
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap(); //reverse so the both direction
        }
    }
}

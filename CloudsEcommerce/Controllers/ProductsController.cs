using AutoMapper;
using CloudsEcommerce.Models;
using Domain;
using Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudsEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected readonly IProductService _productService;
        protected readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<ProductDto> Get()
        {
            return _mapper.Map<List<ProductDto>>(_productService.GetProducts());
        }
    }
}

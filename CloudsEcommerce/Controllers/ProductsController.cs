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
        protected readonly IConfiguration _configuration;
        protected readonly IMapper _mapper;

        public ProductsController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<ProductDto> Get()
        {
            var apiKey = _configuration["api-key"];
            ProductService productService = new(apiKey);
            return _mapper.Map<List<ProductDto>>(productService.GetProducts());
        }
    }
}

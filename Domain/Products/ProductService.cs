using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Domain.Products
{
    public class ProductService : IProductService
    {
        protected readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<Product> GetProducts()
        {
            var client = new RestClient("http://alltheclouds.com.au/api");
            var request = new RestRequest("/Products", Method.Get);
            request.AddHeader("api-key", _configuration["api-key"]);
            try
            {
                var response = client.Get<List<Product>>(request);
                return response?.Select(x => { x.UnitPrice = Math.Round(x.UnitPrice * 1.2, 2); return x; } )?.ToList() ?? new List<Product>();
            } 
            catch (Exception ex)
            {
                throw new Exception("Service not available");
            }


        }
    }
}

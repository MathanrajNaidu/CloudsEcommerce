using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Domain.Products
{
    public class ProductService
    {
        protected readonly string _apiKey;

        public ProductService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public List<Product> GetProducts()
        {
            //var apiKey = "API-DS87LLR1SODY667";
            var client = new RestClient("http://alltheclouds.com.au/api");
            var request = new RestRequest("/Products", Method.Get);
            request.AddHeader("api-key", _apiKey);
            var response = client.Get<List<Product>>(request);
            return response?? new List<Product>();
        }
    }
}

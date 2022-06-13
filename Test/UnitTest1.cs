using Domain.Products;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    public class Tests
    { 
        IConfiguration? _configuration;
        [SetUp]
        public void Setup()
        {
            var myConfiguration = new Dictionary<string, string>
                {
                    {"api-key", "API-DS87LLR1SODY667"}
                };

            _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(myConfiguration)
            .Build();
        }

        [Test]
        public void Test1()
        {
            var productService = new ProductService(_configuration);
            var products = productService.GetProducts();
            Assert.NotZero(products.Count);
        }


       
    }
}
using Domain.Products;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var productService = new ProductService("API-DS87LLR1SODY667");
            var products = productService.GetProducts();
            Assert.NotZero(products.Count);
        }
       
    }
}
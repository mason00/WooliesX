using MasonAzureTest.Api;
using MasonAzureTest.Interfaces;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class ProductControllerTests
    {
        private ProductController _controller;
        private Mock<IProductService> _productService;
        private Mock<IShopperService> _shopperService;

        [SetUp]
        public void Setup()
        {
            _productService = new Mock<IProductService>();
            _shopperService = new Mock<IShopperService>();
            _controller = new ProductController(_productService.Object, _shopperService.Object);
        }

        [Test]
        public async Task GetHistory()
        {
            var result = await _controller.GetHistory("test");

            Assert.NotNull(result);
        }
    }
}
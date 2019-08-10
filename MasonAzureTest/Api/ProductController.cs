using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasonAzureTest.Interfaces;
using MasonAzureTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasonAzureTest.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IShopperService _shopperService;

        public ProductController(IProductService service, IShopperService shopperService)
        {
            _productService = service;
            _shopperService = shopperService;
        }

        [HttpGet]
        public async Task<ActionResult> GetHistory(string token)
        {
            var result = await _productService.GetProducts(token);
            return Ok(result);
        }

        [HttpGet]
        [Route("sort")]
        public async Task<ActionResult> SortShoppingHistory(string sortOption)
        {
            var products = await _productService.GetProducts(Token.Value);

            switch (sortOption)
            {
                case "Low":
                    return Ok(products.OrderBy(p => p.Price));
                case "High":
                    return Ok(products.OrderByDescending(p => p.Price));
                case "Ascending":
                    return Ok(products.OrderBy(p => p.Name));
                case "Descending":
                    return Ok(products.OrderByDescending(p => p.Name));
                case "Recommended":
                    var histories = await _shopperService.GetShopperHistory(Token.Value);

                    var allProducts = histories.SelectMany(h => h.Products);
                    var popularity = from product in allProducts
                                     group product by product.Name into p
                                     select new { Key = p.First().Name, Value = p.Sum(pd => pd.Quantity) };

                    var popularProducts = from product in products
                                          join productPopularity in popularity
                                          on product.Name equals productPopularity.Key
                                          into productGroup
                                          from item in productGroup.DefaultIfEmpty()
                                          select new { Product = product, Total = item?.Value };
                    return Ok(popularProducts.OrderByDescending(qp => qp.Total).Select(pq => pq.Product));
                default:
                    return Ok(products);
            }
        }
    }
}
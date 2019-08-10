using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasonAzureTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasonAzureTest.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleyController : ControllerBase
    {
        [HttpPost]
        [Route("trolleyTotal")]
        public long GetLowestTotal([FromBody] Trolly trolly)
        {
            var price = 0;
            var specialCount = trolly.Specials.Count();
            var productQuantity = from product in trolly.Products
                                  join quantity in trolly.Quantities
                                  on product.Name equals quantity.Name
                                  select new ProductInTrolly
                                  {
                                      Name = product.Name,
                                      Price = product.Price,
                                      Quantity = quantity.Quantity
                                  };
            var productQuantityArray = productQuantity.ToArray();
            for (int i = 0; i < specialCount; i++)
            {
                price += MatchSpecialInProducts(trolly.Specials.Take(i).ToArray(), productQuantityArray);
            }

            return 0;
        }

        private int MatchSpecialInProducts(Special[] special, ProductInTrolly[] products)
        {
            for (int i = 0; i < special.Length; i++)
            {
                foreach (var item in special[i].Quantities)
                {
                    var matchedProduct = products.Where(p => p.Name == item.Name && p.Quantity <= item.Quantity);
                }
            }

            return 0;
        }
    }
}
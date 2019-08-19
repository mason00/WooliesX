using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasonAzureTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MasonAzureTest.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleyController : ControllerBase
    {
        private readonly ILogger _logger;

        public TrolleyController(ILogger<TrolleyController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("trolleyTotal")]
        public decimal GetLowestTotal([FromBody] Trolly trolly)
        {
            var trollyString = JsonConvert.SerializeObject(trolly);
            _logger.LogError($"Trolly: {trollyString}");

            var productQuantity = from product in trolly.Products
                                  join quantity in trolly.Quantities
                                  on product.Name equals quantity.Name
                                  select new ProductInTrolly
                                  {
                                      Name = product.Name,
                                      Price = product.Price,
                                      Quantity = quantity.Quantity
                                  };
            return MatchSpecialInProducts(trolly.Specials, trolly.Quantities, trolly.Products);
        }

        private decimal MatchSpecialInProducts(IEnumerable<Special> specials,
            IEnumerable<TrollyQuantity> quantities,
            IEnumerable<TrollyProduct> products)
        {
            decimal total = 0;

            var orderedSpecial = specials.OrderByDescending(s => s.Total);

            var foundSpecial = false;
            Special currentSpecial = null;

            foreach (var quantity in quantities)
            {
                if (quantity.Quantity == 0)
                {
                    foundSpecial = false;
                    break;
                }

                if (currentSpecial == null)
                {
                    foreach (var special in orderedSpecial)
                    {
                        foundSpecial = special.Quantities.Any(s => s.Name == quantity.Name && s.Quantity <= quantity.Quantity);
                        if (foundSpecial)
                        {
                            currentSpecial = special;
                            break;
                        }
                    }
                }
                else
                {
                    foundSpecial = currentSpecial.Quantities.Any(s => s.Name == quantity.Name && s.Quantity <= quantity.Quantity);
                    if (!foundSpecial)
                    {
                        break;
                    }
                }
            }

            if (foundSpecial)
            {
                total += currentSpecial.Total;
                foreach (var specialQuantity in currentSpecial.Quantities)
                {
                    foreach (var quantity in quantities)
                    {
                        if (specialQuantity.Name == quantity.Name)
                        {
                            quantity.Quantity -= specialQuantity.Quantity;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (var product in products)
                {
                    foreach (var quantity in quantities)
                    {
                        if (quantity.Quantity != 0)
                        {
                            if (quantity.Name == product.Name)
                            {
                                total += product.Price * quantity.Quantity;
                                quantity.Quantity = 0;
                                break;
                            }
                        }
                    }
                }
            }

            if (quantities.Any(q => q.Quantity != 0))
            {
                total += MatchSpecialInProducts(specials, quantities, products);
            }

            return total;
        }
    }
}
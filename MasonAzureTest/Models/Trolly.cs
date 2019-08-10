using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasonAzureTest.Models
{
    public class Trolly
    {
        public IEnumerable<TrollyProduct> Products { get; set; }
        public IEnumerable<Special> Specials { get; set; }
        public IEnumerable<TrollyQuantity> Quantities { get; set; }
    }
}

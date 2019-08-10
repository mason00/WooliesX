using System.Collections.Generic;

namespace MasonAzureTest.Models
{
    public class History
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}

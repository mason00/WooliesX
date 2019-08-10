using MasonAzureTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasonAzureTest.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts(string token);
    }
}

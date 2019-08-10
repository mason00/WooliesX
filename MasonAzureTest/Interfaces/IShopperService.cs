using MasonAzureTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasonAzureTest.Interfaces
{
    public interface IShopperService
    {
        Task<IEnumerable<History>> GetShopperHistory(string token);
    }
}
using MasonAzureTest.Interfaces;
using MasonAzureTest.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasonAzureTest.Services
{
    public class ShopperService : IShopperService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string Url = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory";

        public ShopperService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<History>> GetShopperHistory(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{Url}?token=1f2c0c32-1aa6-40b2-b523-106868028331");
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content
                    .ReadAsAsync<IEnumerable<History>>();
            }
            else
            {
                return Array.Empty<History>();
            }
        }
    }
}

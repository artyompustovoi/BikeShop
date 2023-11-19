//using NiceBikeShopBlazorFrontend.Models;
using NiceBikeShopBackend.Data;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace NiceBikeShop.HttpApiClient
{
    public class NiceBikeShopClient
    {
        private readonly string _host;
        private readonly HttpClient _httpClient;

        public NiceBikeShopClient(HttpClient httpClient, string host)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentException($"\"{nameof(host)}\" не может быть неопределенным или пустым.", nameof(host));
            }

            if (httpClient is null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            _host = host;
            _httpClient = httpClient;
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {

            
            //var uri = $"{_host}/api/products";

            var uri = $"{_host}/api/products";
            var products = await _httpClient.GetFromJsonAsync<IReadOnlyList<Product>>(uri);
            return products!;
        }
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var uri = $"{_host}/api/get_product_by_id/{{ProductId}}?ProductId={id}";
            var product = await _httpClient.GetFromJsonAsync<Product>(uri);
            return product!;
        }

        public async Task AddNewProducAsync(Product p)
        {
            var uri = $"{_host}/api/products/add";
            await _httpClient.PostAsJsonAsync(uri, p);
        }

        public async Task EditProductAsync(Product p)
        {
            //var uri = $"{_host}/api//id";

            var uri = $"{_host}/api/products/edit";
            await _httpClient.PostAsJsonAsync(uri, p);

        }
        public async Task DeleteProductAsync(Product p)
        {
            //var uri = $"{_host}/api//id";

            var uri = $"{_host}/api/products/delete";
            await _httpClient.PostAsJsonAsync(uri, p);

        }
    }
}
using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;

namespace NiceBikeShopBlazorFrontend.Models
{
    public interface ICatalog
    {
        public List<Product> GetProducts();
        public EventCallback CreateProduct(Product product);
        public Product GetProductById(Guid guid);
        public List<Product> GetProductsByCategoryId(IEnumerable<int> categoryId);
        //public void DeleteProduct(Guid guid);
        //public void EditProduct(Guid guid, string newName, decimal newPrice);
    }
}

using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;

namespace NiceBikeShopBlazorFrontend.Models
{
    public class InMemoryCatalog : ICatalog
    {
        List<Product> _products = new List<Product>();
        //ConcurrentDictionary<Guid, Product> _products = new ConcurrentDictionary<Guid, Product>();

        public InMemoryCatalog()
        {

            _products.Add(new Product(Guid.NewGuid(), "bike1", 40m, 1));
            _products.Add(new Product(Guid.NewGuid(), "bike2", 50m, 1));
            _products.Add(new Product(Guid.NewGuid(), "bike3", 60m, 2));
            //_products.Add(new Product(Guid.NewGuid(), "product4", 70m));
            //_products.Add(new Product(Guid.NewGuid(), "product5", 80m));
        }


        public List<Product> GetProducts()
        {
            return _products;
        }
        public EventCallback CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _products.Add(product);
            return new EventCallback();

        }



        public Product GetProductById(Guid guid)
        {
            foreach (var product in _products)
            {
                if (product.Id == guid)
                    return product;
            }
            return new Product(Guid.NewGuid(), "not found", 0, 1);
        }
        public List<Product> GetProductsByCategoryId(IEnumerable<int> categoryId)
        {
            List<Product> productsByCategory = new List<Product>();

            foreach (var product in _products)
            {
                foreach (var category in categoryId)
                {
                    if (product.categoryId == category)
                        productsByCategory.Add(product);
                }

            }
            return productsByCategory;
        }

        //public void DeleteProduct(Guid guid)
        //{
        //    _products.TryRemove(new KeyValuePair<Guid, Product>(guid, _products[guid]));
        //}


        //public void EditProduct(Guid guid, string newName, decimal newPrice)
        //{
        //    _products[guid].Name = newName;
        //    _products[guid].Price = newPrice;

        //}
    }
}

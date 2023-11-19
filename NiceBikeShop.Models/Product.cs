namespace NiceBikeShopBackend.Data
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int categoryId { get; set; }
        public decimal Price { get; set; }

        public Product(Guid Id, string Name, int categoryId, decimal Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.categoryId = categoryId;
            this.Price = Price;
        }
        //public void addProduct()
        //{
        //    Product product = new Product();
        //    product.Id = Guid.NewGuid();
        //    product.Name = "Name";
            
        //}
    }
}

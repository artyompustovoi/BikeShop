namespace NiceBikeShopBlazorFrontend.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int categoryId { get; set; }
        public decimal Price { get; set; }
        public Product(Guid guid, string name, decimal price, int categoryId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price));
            }
            Name = name;
            Price = price;
            Id = guid;
            this.categoryId = categoryId;
            var currentDateTime = DateTime.Now;
            if (currentDateTime.DayOfWeek == DayOfWeek.Sunday)
                Price = price * 0.5m;
            else
                Price = price;
        }

    }
}

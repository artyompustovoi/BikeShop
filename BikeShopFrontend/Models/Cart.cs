namespace NiceBikeShopBlazorFrontend.Models
{
    public class Cart : ICart
    {

        List<Product> _purchases = new();
        public void addProductToCart(Product purchase)
        {
            _purchases.Add(purchase);
        }



        public void deletePurchase(Product product)
        {
            _purchases.Remove(product);
        }
        public List<Product> getPurchases()
        {
            return _purchases;
        }


    }
}

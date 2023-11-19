using NiceBikeShopBlazorFrontend.Models;
using System.Collections.Concurrent;

namespace NiceBikeShopBlazorFrontend.Pages
{
    public partial class CartPage
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            //
            _purchases = cart.getPurchases();

        }
      
        List<Product> _purchases;
       

    }
}

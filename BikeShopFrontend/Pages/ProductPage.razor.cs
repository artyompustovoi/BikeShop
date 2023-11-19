using Microsoft.AspNetCore.Components;
using NiceBikeShopBlazorFrontend.Models;
using Product = NiceBikeShopBackend.Data.Product;

namespace NiceBikeShopBlazorFrontend.Pages
{
    public partial class ProductPage
    {
        [Parameter]
        public Guid ProductId { get; set; }
        private Product _product { get; set; }
        

  
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _product = await apiClient.GetProductByIdAsync(ProductId);
            imageSource = $"ProductImages/{_product.Name}.jpg";
        }

    }
}


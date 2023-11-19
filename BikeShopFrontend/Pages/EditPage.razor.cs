using Microsoft.AspNetCore.Components;
using Product = NiceBikeShopBackend.Data.Product;

namespace NiceBikeShopBlazorFrontend.Pages
{
    public partial class EditPage
    {
        [Parameter]
        public Guid ProductId { get; set; }
        private Product? _product = null;



        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _product = await apiClient.GetProductByIdAsync(ProductId);
            //imageSource = $"ProductImages/{_product.Name}.jpg";
        }
    }
}

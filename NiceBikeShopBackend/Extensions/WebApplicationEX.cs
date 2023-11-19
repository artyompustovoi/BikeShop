using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceBikeShopBackend.Data;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace NiceBikeShopBackend.Extensions
{
    public static class IApplicationBuilderExtensions
    {
     
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", (AppDBContext dbContext) =>
            {
                return dbContext.Products.ToListAsync();
            });

            app.MapPost("/api/products/add", async (
                [FromServices] AppDBContext dbContext, [FromBody] Product product) =>
            {
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
            });

            app.MapGet("/api/get_product_by_id/{ProductId}", async (
               [FromServices] AppDBContext dbContext, [FromQuery] Guid ProductId) =>
            {
                
                var p = dbContext.Products.First(a => a.Id == ProductId);
                return p;
                //await dbContext.SaveChangesAsync();
            });



            app.MapPost("/api/products/edit", async (
               [FromServices] AppDBContext dbContext, [FromBody] Product product) =>
            {

                var p = dbContext.Products.First(a => a.Id == product.Id);
                p.Name = product.Name;
                p.Price = product.Price;
                p.categoryId = product.categoryId;


                dbContext.SaveChanges();
            });

            app.MapPost("/api/products/delete", async (
                [FromServices] AppDBContext dbContext, [FromBody] Product product) =>
            {
                //CancellationToken new c;
                //await dbContext.Products.ExecuteDeleteAsync<>();
                await dbContext.Products.Where(p => p.Id == product.Id).ExecuteDeleteAsync();
                await dbContext.SaveChangesAsync();
            });

            return app;
        }
    }
}

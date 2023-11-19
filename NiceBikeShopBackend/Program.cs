using Microsoft.EntityFrameworkCore;
using NiceBikeShopBackend.Data;
using NiceBikeShopBackend.Extensions;

namespace NiceBikeShopBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
 

            builder.Services.AddDbContext<AppDBContext>(
                options =>
                {
                    options.UseSqlite(builder.Configuration.GetConnectionString("AppDb"));
                });

            builder.Services.AddCors();


            var app = builder.Build();
            app.UseCors(policy =>
            {
                policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
            });
            app.UseCors(policy =>
                policy.WithOrigins("https://localhost:44398")
                
                );


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapProductEndpoints();

            app.MapControllers();

            app.Run();
        }
    }
}
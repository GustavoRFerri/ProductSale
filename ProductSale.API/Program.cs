using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using ProductSale.Application.service;
using ProductSale.Infrastructure.repositories;

namespace ProductSale.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IDiscountService, DiscountService>();
            builder.Services.AddScoped<IRepositorySale, RepositorySale>();
            builder.Services.AddScoped<IDeleteProductService,DeleteProductService>();
            builder.Services.AddScoped<ISearchProductService, SearchProductService>();
            builder.Services.AddScoped<IQuantityProductService, QuantityProductService>();
            builder.Services.AddScoped<IChangeProductService,ChangeProductService>();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

}

using Microsoft.Extensions.Logging;
using Moq;
using ProductSale.Application.service;
using ProductSale.Core.entities;
using ProductSale.Infrastructure.repositories;
using System.Text.Json;

namespace TestDeveloperStore
{

    public class CreateTest
    {
        private readonly Mock<IDiscountService> mockDiscountService = new();
        
        private readonly Mock<ILogger<QuantityProductService>> mockLogger = new();
        private readonly Mock<IRepositorySale> mockRepositorySale = new();

        private readonly QuantityProductService _quantityProductService; 
        List<Product> listProduct = new List<Product>();


        public CreateTest()
        {            
            _quantityProductService = new QuantityProductService(
                mockRepositorySale.Object,
                mockDiscountService.Object,
                mockLogger.Object
                );
        }
       

        [Theory(DisplayName ="Create new products")]
        [InlineData("Anna")]
        public async Task Test_Create_Sale_Lot_Of_Products(string name)
        {

            var discServiceMock = new Mock<IDiscountService>();
            discServiceMock.Setup(m => m.ApplyDiscount(It.IsAny<int>(),It.IsAny<decimal>())).Returns((int id, decimal valor) => valor * 0.9m);
            var repositorySaleMock = new Mock<IRepositorySale>();
            var loggerMock = new Mock<ILogger<QuantityProductService>>();
            var qtdProdService = new QuantityProductService(repositorySaleMock.Object, discServiceMock.Object, loggerMock.Object);
            

            // Given
            for (int i = 0; i < 7; i++)
            {
                var Sale = new Product
                {
                    Kind = "Computer",
                    Price = 50
                };
                listProduct.Add(Sale);
            }

            for (int i = 0; i < 3; i++)
            {
                var Sale = new Product
                {
                    Kind = "Shoes",
                    Price = 30
                };
                listProduct.Add(Sale);
            }

            for (int i = 0; i < 13; i++)
            {
                var Sale = new Product
                {
                    Kind = "Bag",
                    Price = 15
                };
                listProduct.Add(Sale);
            }


            for (int i = 0; i < 23; i++)
            {
                var Sale = new Product
                {
                    Kind = "Gloves",
                    Price = 25
                };
                listProduct.Add(Sale);
            }
            // when
            // 
            string dd = JsonSerializer.Serialize(listProduct);

            // with Service
            Sale discountProducts = qtdProdService.CountProduct(listProduct, name);           

            // then
            Assert.NotNull(discountProducts);

        }


        [Theory]
        [InlineData(3, "Erick")]
        public async Task Test_Create_Sale_Same_Product_(int quantity, string name)
        {
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var sale = new Product
                {
                    Kind = "Bag",
                    Price = 10
                };
                listProduct.Add(sale);
            }

            // when
            // with Service
            Sale discountProducts = _quantityProductService.CountProduct(listProduct, name);

            // then
            Assert.NotNull(discountProducts);
        }


    }
}
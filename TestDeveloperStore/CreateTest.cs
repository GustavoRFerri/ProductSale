using Microsoft.Extensions.Logging;
using Moq;
using ProductSale.Application.service;
using ProductSale.Application.service.@interface;
using ProductSale.Core.entities;
using ProductSale.Infrastructure.repositories;

namespace TestDeveloperStore
{

    public class CreateTest
    {
        private readonly Mock<IDiscountService> mockDiscountService = new();
        private readonly Mock<ILogger<QuantityProductService>> mockLogger = new();
        private readonly Mock<IRepositorySale> mockRepositorySale = new();
        

        private readonly QuantityProductService _quantityProductService;
        
        Sale sale = new Sale();
        List<Product> listProduct = new List<Product>();


        public CreateTest()
        {            
            _quantityProductService = new QuantityProductService(
                mockRepositorySale.Object,
                mockDiscountService.Object,
                mockLogger.Object
                );
        }


        [Theory]
        [InlineData(7, "Jhon")]
        public async Task Test_Create_Sale_Above_Four_Product(int quantity, string name)
        {

            var dfds = new Mock<IDiscountService>();
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var Sale = new Product
                {
                    Kind = "Shoes",
                    Price = 10
                };
                listProduct.Add(Sale);
            }

            //when
            //SaleProductController saleProductController = new SaleProductController();
            //decimal discountFourProducts = await saleProductController.SaleCreated(listProduct, name);

            //with Service
            //DiscountService discountService = new DiscountService();
            //Sale discountFourProducts = discountService.DiscountAboveFourProducts2(listProduct);

            // then
            // Assert.Equal(63, discountFourProducts.Discount);
        }

        [Theory(DisplayName ="Create new products")]
        [InlineData("Anna")]
        public async Task Test_Create_Sale_Between_10_20_More_Product(string name)
        {
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
            //var testeMock = new Mock<IQuantityProductService>();
            //var teste2 = new QuantityProductService(testeMock.Object);
            //SaleProductController saleProductController = new SaleProductController();

            // with Service
            Sale discountFourProducts = _quantityProductService.CountProduct(listProduct, name);           

            // then
            Assert.NotNull(discountFourProducts);

        }


        [Theory]
        [InlineData(3, "Erick")]
        public async Task Test_Create_Sale_below_four(int quantity, string name)
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
            //SaleProductController saleProductController = new SaleProductController();
            //decimal discountFourProducts = await saleProductController.SaleCreated(listProduct, name);

            // with Service
            DiscountService discountService = new DiscountService();
            //Sale discountFourProducts = discountService.DiscountBeteween_10_20_Products(listProduct);

            // then
            //Assert.Equal(0, discountFourProducts.Discount);
        }


    }
}
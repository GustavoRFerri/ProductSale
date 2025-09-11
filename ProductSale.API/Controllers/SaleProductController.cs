using Microsoft.AspNetCore.Mvc;
using ProductSale.Application.service;

using ProductSale.Core.entities;

namespace ProductSale.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleProductController : ControllerBase
    {
        private readonly ILogger<SaleProductController> _logger;
        private readonly IChangeProductService _changeProductService;
        private readonly IDeleteProductService deleteProductService;

        private ISearchProductService _searchProductService;

        //private IDataBaseSale _dataBaseSale;
        private IQuantityProductService _quantityProductService;

        // TO DO TESTS

        //public SaleProductController()
        //{

        //}

        public SaleProductController(ILogger<SaleProductController> logger, IChangeProductService changeProductService, IQuantityProductService quantityProductService, ISearchProductService searchProductService)
        {
            _logger = logger;
            _changeProductService = changeProductService;
            _quantityProductService = quantityProductService;
            _searchProductService = searchProductService;
            //_dataBaseSale = dataBaseSale;
        }

        [HttpGet(Name = "GetSale")]
        public async Task<IActionResult> GetSale()
        {
            var result = await _searchProductService.GetAllSale();
            return Ok(result);
        }

        [HttpPost(Name = "CreateSale")]
        public async Task<IActionResult> SaleCreated(List<Product> products, string customer)
        {        
            _logger.LogInformation("INICIANDO Creating of Sale ");
            Sale valuesSale = _quantityProductService.CountProduct(products, customer);            
            return CreatedAtAction(nameof(GetSale), new { id = valuesSale._id }, valuesSale);
        }

        [HttpPut("SaleCancell/{id}")]
        public async Task<IActionResult> SaleCancelled(string id)
        {
            // Cancell the product
            return Ok(await _changeProductService.CancelProduct(id));
        }


        [HttpPut("SaleModifiedDiscount/{id}")]
        public async Task<IActionResult> SaleModified(string id, decimal disc)
        {
           // return Ok(await _dataBaseSale.UpDate(id, disc));
           return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public void Del(string id)
        {
            //_dataBaseSale.Delete(id);
        }

    }
}


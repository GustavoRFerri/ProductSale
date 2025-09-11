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
        private readonly IDeleteProductService _deleteProductService;
        private readonly ISearchProductService _searchProductService;

        //private IDataBaseSale _dataBaseSale;
        private IQuantityProductService _quantityProductService;

        // TO DO TESTS

        //public SaleProductController()
        //{

        //}

        public SaleProductController(ILogger<SaleProductController> logger, IChangeProductService changeProductService, IDeleteProductService deleteProductService, IQuantityProductService quantityProductService, ISearchProductService searchProductService)
        {
            _logger = logger;
            _changeProductService = changeProductService;
            _deleteProductService = deleteProductService;
            _quantityProductService = quantityProductService;
            _searchProductService = searchProductService;
            //_dataBaseSale = dataBaseSale;
        }

        [HttpPost(Name = "CreateSale")]
        public async Task<IActionResult> SaleCreated([FromBody] Cart cart)
        {
            _logger.LogInformation(" Startting creating of Sale ");
            Sale valuesSale = _quantityProductService.CountProduct(cart);
            return CreatedAtAction(nameof(GetSale), new { id = valuesSale._id }, valuesSale);
        }

        [HttpGet(Name = "GetSale")]
        public async Task<IActionResult> GetSale()
        {
            var result = await _searchProductService.GetAllSale();
            return Ok(result);
        }


        [HttpGet("GetIdSale/{id}")]
        public async Task<IActionResult> GetIdSale(string id)
        {
            var result = await _searchProductService.GetIdSale(id);

            if (result is null)            
                return NotFound(" Product didn´t found ");            
            else
                return Ok(result);
        }

      

        [HttpPut("SaleCancell/{id}")]
        public async Task<IActionResult> SaleCancelled(string id)
        {
            // Cancell the product
            var sale = await _changeProductService.CancelProduct(id);

             if (sale is null)            
                return NotFound(" Product didn´t found ");            
            else            
                return Ok(sale);
        }
      

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Del(string id)
        {
            Sale sl = await _deleteProductService.DeleteProduct(id);
            if (sl is null)            
                return NotFound(" Product didn´t found ");            
            else            
                return Ok(sl);            
        }

    }
}


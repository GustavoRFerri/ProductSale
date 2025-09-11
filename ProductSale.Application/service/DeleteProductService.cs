using ProductSale.Core.entities;
using ProductSale.Infrastructure.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Application.service
{
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IRepositorySale _repositorySale;
        private readonly ISearchProductService _searchProductService;


        public DeleteProductService( IRepositorySale repositorySale, ISearchProductService searchProductService)
        {
            _repositorySale = repositorySale;
            _searchProductService = searchProductService;
        }

        public async Task<Sale> DeleteProduct(string id)
        {
            try
            {               
                Sale sales = await _repositorySale.GetIdSale(id);

                if (sales == null)
                    return null;
                else
                {
                    await _repositorySale.Delete(id);
                    return sales;
                }
            }
            catch (Exception x)
            {

                throw;
            }
        }
    }
}

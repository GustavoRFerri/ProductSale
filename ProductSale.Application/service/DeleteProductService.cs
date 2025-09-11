using ProductSale.Core.entities;
using ProductSale.Infrastructure.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Application.service
{
    internal class DeleteProductService : IDeleteProductService
    {
        private readonly IRepositorySale _repositorySale;


        public DeleteProductService( IRepositorySale repositorySale)
        {
            _repositorySale = repositorySale;
        }

        public Task<Sale> DeleteProduct(string id)
        {
            return _repositorySale.Delete(id);
        }
    }
}

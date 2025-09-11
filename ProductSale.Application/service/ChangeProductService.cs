using ProductSale.Application.service;
using ProductSale.Core.entities;
using ProductSale.Infrastructure.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Application.service
{
    public class ChangeProductService : IChangeProductService
    {
        private readonly IRepositorySale _repositorySale;

        public ChangeProductService(IRepositorySale repositorySale)
        {
            _repositorySale = repositorySale;
        }


        public async Task<Sale> CancelProduct(string id)
        {            
            Sale sale = await _repositorySale.SaleCancelled(id); // Replace "id" with the actual id of the sale to cancel   

            return sale;
        }



    }
}

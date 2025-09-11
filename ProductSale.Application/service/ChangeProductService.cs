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
        private readonly ISearchProductService _searchProductService;

        public ChangeProductService(IRepositorySale repositorySale, ISearchProductService searchProductService)
        {
            _repositorySale = repositorySale;
            _searchProductService = searchProductService;
        }


        public async Task<Sale> CancelProduct(string id)
        {
            Sale sl = await _repositorySale.GetIdSale(id);

            if (sl == null)
                return null;
            else
            {
                await _repositorySale.SaleCancelled(id);
                return sl;
            }            
        }



    }
}

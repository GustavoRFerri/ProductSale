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
    public class SearchProductService : ISearchProductService
    {
        private readonly IRepositorySale _repositorySale;

        public SearchProductService(IRepositorySale repositorySale)
        {
            _repositorySale = repositorySale;             
        }


        public async Task<List<Sale>> GetAllSale()
        {
            List<Sale> sales = await _repositorySale.GetSale();
            return sales;
        }

        public async Task<Sale> GetIdSale(string id)
        {
            Sale sales = await _repositorySale.GetIdSale(id);

            if (sales is null)            
                return null;
            else            
                return sales;
        }

    }
}

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
        RepositorySale dataSale = new RepositorySale();

        public async Task<List<Sale>> GetAllSale()
        {
            List<Sale> sales = await dataSale.GetSale();
            return sales;
        }
    }
}

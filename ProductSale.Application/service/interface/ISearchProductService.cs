using ProductSale.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Application.service
{
    public interface ISearchProductService
    {
        Task<List<Sale>> GetAllSale();
        Task<Sale> GetIdSale(string id);
    }

}
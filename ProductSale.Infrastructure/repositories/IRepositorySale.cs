using ProductSale.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Infrastructure.repositories
{
    public interface IRepositorySale
    {
        Task<List<Sale>> GetSale();
        Task<Sale> GetIdSale(string id);
        Task Input(Sale sale);
        Task<Sale> UpDate(string id, decimal disc);
        Task<Sale> SaleCancelled(string id);
        Task Delete(string id);
    }
}

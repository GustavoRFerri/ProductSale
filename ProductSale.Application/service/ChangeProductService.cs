using ProductSale.Application.service.@interface;
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

        public void CancelProduct(int id)
        {
            RepositorySale _repositorySale = new RepositorySale();
            _repositorySale.SaleCancelled("id"); // Replace "id" with the actual id of the sale to cancel   
        }



    }
}

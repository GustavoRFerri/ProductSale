using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Application.service.@interface
{
    public interface IChangeProductService
    {
        public void CancelProduct(int id);
    }
}

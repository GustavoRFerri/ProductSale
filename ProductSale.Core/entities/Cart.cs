using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Core.entities
{
    public class Cart
    {
        public string NameCustomer {  get; set; }
        public List<Product> ListProducts { get; set; }
    }
}

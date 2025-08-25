using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Core.dto
{
    public class ProductDTO
    {
        public string Kind { get; set; }
        public decimal EachPrice { get; set; }
        public int EachQuantity { get; set; }
        public decimal EachDiscount { get; set; }
    }
}

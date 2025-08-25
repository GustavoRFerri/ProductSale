using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProductSale.Core.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Core.entities
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public DateTime DateTime { get; set; }
        // public Guid SaleNumber { get; set; }
        public string Customer { get; set; }
        public int FinalQuantities { get; set; }
        public decimal FinalDiscount { get; set; }
        public decimal FinalTotal { get; set; }
        public bool Cancelled { get; set; }
        public List<ProductDTO> ProductDTO { get; set; }
    }
}

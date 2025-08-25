using MongoDB.Bson;
using MongoDB.Driver;
using ProductSale.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSale.Infrastructure.repositories
{
    public class RepositorySale : IRepositorySale
    {
        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly IMongoCollection<Sale> _collection;

        public RepositorySale()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Sale");
            _collection = database.GetCollection<Sale>("Product");
        }

        public async Task<List<Sale>> GetSale()
        {
            List<Sale> Sle = await _collection.Find(new BsonDocument()).ToListAsync();

            if (Sle is not null)
            {
                return Sle;
            }
            else
            {
                return new List<Sale>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Sale>> GetId(int id)
        {
            //var prod = _collection.Find(filter: sale => sale._id == id).FirstOrDefault();

            //if (prod is not null)
            //{
            //    return prod;
            //}
            //else
            //{
            //    return new List<Sale>();
            //}

            return new List<Sale>();
        }

        public async Task Input(Sale sale)
        {
            try
            {
                await _collection.InsertOneAsync(sale);
            }
            catch (Exception ex)
            {
                // Message error
                // ex.Message()
            }
        }


        public async Task<Sale> UpDate(string id, decimal disc)
        {
            try
            {
                var prod = _collection.Find(filter: sale => sale._id == id).FirstOrDefault();
                prod.FinalDiscount = disc;
                _collection.ReplaceOne(filter: sale => prod._id == sale._id, prod);

                Sale prodChanged = await _collection.Find(filter: sale => sale._id == id).FirstOrDefaultAsync();

                return prodChanged;
            }
            catch (Exception ex)
            {
                Sale sale = new Sale();
                return sale;
            }

        }

        public async Task<Sale> SaleCancelled(string id)
        {
            try
            {
                var prod = _collection.Find(filter: sale => sale._id == id).FirstOrDefault();
                prod.Cancelled = true;
                _collection.ReplaceOne(filter: sale => prod._id == sale._id, prod);
                Sale sale = await _collection.Find(filter: sale => sale._id == id).FirstOrDefaultAsync();

                return sale;
            }
            catch (Exception ex)
            {
                Sale sale = new Sale();
                return sale;
            }
        }


        public async Task<Sale> Delete(string id)
        {
            try
            {
                var prod = _collection.Find(filter: sale => sale._id == id).FirstOrDefault();
                var deleteResult = _collection.DeleteOne(prod._id);
                _collection.DeleteOne(prod._id);
                Sale sale = await _collection.Find(filter: sale => sale._id == id).FirstOrDefaultAsync();

                return sale;
            }
            catch (Exception ex)
            {
                Sale sale = new Sale();
                return sale;
            }
        }


    }

}

using SearchProductCatalogue.Domain;
using SearchProductCatalogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchProductCatalogue.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabase _database;

        public ProductRepository(IDatabase database)
        {
            _database = database;
        }

        public void Add(Product product)
        {
            _database.Add(product);
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using SearchProductCatalogue.Domain.Entities;

namespace SearchProductCatalogue.Infrastructure
{
    public class Database : IDatabase
    {
        private readonly Dictionary<string, Product> _database = new Dictionary<string, Product>();


        public void Add(Product product)
        {
            _database.Add(product.Id, product);
        }
    }
}
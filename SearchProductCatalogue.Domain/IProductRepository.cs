using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchProductCatalogue.Domain.Entities;

namespace SearchProductCatalogue.Domain
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        void Add(Product product);
    }
}
